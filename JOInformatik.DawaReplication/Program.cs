using JOInformatik.DawaReplication.DataAccess;
using JOInformatik.DawaReplication.Helpers;
using JOInformatik.DawaReplication.Helpers.MSApplicationInsightsHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace JOInformatik.DawaReplication
{
    /// <summary>
    /// Main method holder class.
    /// </summary>
    public static class Program
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger("DawaReplication");

        /// <summary>
        /// Main program.
        /// </summary>
        /// <param name="args">String arguments for program initialization.</param>
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var settings = Properties.Settings.Default;

            if (settings.UseMSApplicationInsights)
            {
                try
                {
                    ApplicationInsightInitializer.Initialize();
                }
                catch (Exception ex)
                {
                    var msg = $"ERROR! Failed to initialize MS Application Insights. Problem: {ex.Message}";
                    Console.WriteLine(msg);
                    _logger.Error(msg, ex);
                    Environment.Exit((int)ReturnCode.ApplicationInsightInitializeError);
                }
            }

            Helpers.InitializeHelpers.HaltIfNoDBConnection();
            Helpers.InitializeHelpers.HaltIfAllreadyRunning();

            try
            {
#pragma warning disable CS0436 // Type conflicts with imported type
                SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
#pragma warning restore CS0436 // Type conflicts with imported type

                string programAssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                string dataAccessAssemblyVersion = Assembly.GetAssembly(typeof(Adgangsadresse)).GetName().Version.ToString();
                var methodName = LoggingUtils.GetMethodName();
                Console.WriteLine($"Starting DawaReplication assembly ver. {programAssemblyVersion}; DataAccess ver. {dataAccessAssemblyVersion} ....");
                _logger.Info($"{methodName}: Starting DawaReplication assembly ver. {programAssemblyVersion}; DataAccess ver. {dataAccessAssemblyVersion}");
                _logger.Info($"{methodName}: Settings = {SettingsHelper.SettingsAsString()}");
                _logger.Info($"{methodName}: Time of initialization: {DateTime.Now.ToShortTimeString()}");

                var processMode = InitialArgumentHelper.InitializeProcess(args);
                Helpers.InitializeHelpers.HaltIfDBSchemeNotInitialized();

                Console.WriteLine($"Time: {DateTime.Now.ToShortTimeString()}. ProcessMode: {processMode}\n");
                var list = TableInfo.GetTableInfoList(AppDomain.CurrentDomain.BaseDirectory + settings.TableInfoFile, false);

#pragma warning disable CA2000 // Dispose objects before losing scope
                var dbContext = new DawaReplicationDBContext();
#pragma warning restore CA2000 // Dispose objects before losing scope
                if (processMode == EntityProcessMode.Udtraek)
                {
                    FixDBProblems.FixDbProblems(dbContext);
                }

                EntityManager.InitSettings(dbContext, list.Select(x => x.Name).ToList(), settings.DawaApiUri, settings.DawaTestApiUri, settings.DawaApiReadTimeoutInSeconds, settings.UdtraekRowsMax, settings.UdtraekBulkSize, settings.DKStedDataStartPos, settings.DKStedBulkSize, settings.DBCommandTimeoutInSeconds, settings.TempDataFolderPath, settings.ActiveFixes, settings.ActiveFixesListFileLocation, settings.UseMSApplicationInsights);

                LocalDataHelper.MakeFolder(settings.TempDataFolderPath);

                var msg = LoggingUtils.MakeMessage(methodName, " TableInfoFile", list);
                _logger.Info(msg);

                var watch = Stopwatch.StartNew();
                var dawaProcessInfo = Helpers.InitializeHelpers.MakeDawaProcessInfo(processMode, settings.DawaApiUri, settings.DawaApiReadTimeoutInSeconds, settings.TxidOverride);
                _logger.Info($"{methodName}: Got latest transaction ID = {dawaProcessInfo.Txid}");

                EntityManager.ProcessTables(processMode, dawaProcessInfo);

                if (dawaProcessInfo.FailedTables.Any() && (processMode == EntityProcessMode.Dagi || processMode == EntityProcessMode.Udtraek))
                {
                    for (int i = 1; i <= settings.RetryCount; i++)
                    {
                        msg = $"{methodName}: Failed to process all tables. No of failed tables: {dawaProcessInfo.FailedTables.Count}. Retrying again in {settings.RetryTimerInMinutes * i} minutes.";
                        Console.WriteLine($"\nWARNING. Time: {DateTime.Now.ToShortTimeString()}. {msg}");
                        _logger.Warn(msg);
                        EntityManager.TableList = new List<string>(dawaProcessInfo.FailedTables);
                        dawaProcessInfo.FailedTables.Clear();
                        Thread.Sleep(settings.RetryTimerInMinutes * 60 * 1000 * i);
                        EntityManager.ProcessTables(processMode, dawaProcessInfo);
                        if (dawaProcessInfo.FailedTables.Count == 0)
                        {
                            break;
                        }
                    }
                }

                if (processMode == EntityProcessMode.Dagi)
                {
                    LocalDataHelper.CleanUpHelper(settings.EntitystateHistoryDeleteOldNumOfDays, settings.ArchiveLogsAfterDays, settings.DeleteOldArchivesAfterDays, settings.DeleteLogsAfterDays);
                }

                dbContext.Dispose();
                _logger.Info($"{methodName}: Done. Execution time: {watch.Elapsed}");
                _logger.Info($"{methodName}: Time of completion: {DateTime.Now.ToShortTimeString()}");

                if (settings.UseMSApplicationInsights)
                {
                    TelemetryHelper.AddTime(methodName, watch.Elapsed.TotalMinutes, "Minutes");
                }

                if (settings.WaitForUserInput)
                {
                    Console.WriteLine($"Done: {DateTime.Now.ToShortTimeString()}. Execution time: {watch.Elapsed}" + "\n");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                var msg = $"ERROR! Unexpected exception. Problem: {ex.Message}";
                Console.WriteLine(msg);
                Console.WriteLine($"Time at which error occured {DateTime.Now.ToShortTimeString()}");
                _logger.Error(msg, ex);

                if (Properties.Settings.Default.WaitForUserInput)
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }

                Environment.Exit((int)ReturnCode.UnknownError);
            }

            Environment.Exit((int)ReturnCode.Success);
        }
    }
}
