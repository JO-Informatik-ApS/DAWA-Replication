using EFCore.BulkExtensions;
using JOInformatik.DawaReplication.DataAccess;
using JOInformatik.DawaReplication.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace JOInformatik.DawaReplication
{
    /// <summary>Control if we are doing Udtraek (=bootload) or Updates.</summary>
    public enum EntityProcessMode
    {
        /// <summary>Initial bootload of database.</summary>
        Udtraek,

        /// <summary>Syncing database with latest changes.</summary>
        Update,

        /// <summary>Reload all dagi tables.</summary>
        Dagi,
    }

    /// <summary>
    /// Maintains data in the Dawa database.
    /// </summary>
    public static class EntityManager
    {
        #region Fields

        /// <summary>Initializes static members of the <see cref="EntityManager"/> class.
        static EntityManager()
        {
            Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>Gets or sets log4net instance.</summary>
        public static log4net.ILog Logger { get; set; }

        /// <summary>Gets or sets DawaReplicationDBContext instance.</summary>
        public static DawaReplicationDBContext DBContext { get; set; }

        /// <summary>Gets or sets the list of tables to process.</summary>
        public static List<string> TableList { get; set; }

        /// <summary>Gets or sets Dawa API uri. Typical 'https://dawa.aws.dk/'.</summary>
        public static string DawaApiUri { get; set; }

        /// <summary>Gets or sets Dawa Test API uri.</summary>
        public static string DawaTestApiUri { get; set; }

        /// <summary>Gets or sets Dawa API timeout in seconds. Defaults to 300 seconds.</summary>
        public static int ReadTimeoutInSeconds { get; set; }

        /// <summary>Gets or sets max number of rows to read. When 0 all rows are read.</summary>
        public static int UdtraekRowsMax { get; set; }

        /// <summary>Gets or sets the number of elements to insert into the database at a time.</summary>
        public static int UdtraekBulkSize { get; set; }

        /// <summary> Gets or sets the starting position for reading Steder and Sted_navne data.</summary>
        public static int DKStedDataStartPos { get; set; }

        /// <summary>Gets or sets the number of elements to insert into the database at a time while downloading DAGI.</summary>
        public static int DKStedBulkSize { get; set; }

        /// <summary> Gets or sets the folder location for temporary data.</summary>
        public static string TempDataFolderPath { get; set; }

        /// <summary> Gets or sets a value indicating whether any fixes need to be applied.</summary>
        public static bool ActiveFixes { get; set; }

        /// <summary> Gets or sets a value indicating whether any fixes need to be applied.</summary>
        public static string ActiveFixesListFileLocation { get; set; }

        /// <summary> Gets or sets the boolean for using Microsoft Application Insights.</summary>
        public static bool UseMSApplicationInsights { get; set; }

#pragma warning disable IDE0044 // Add readonly modifier
        private static List<FixInfo> fixInfoList = new List<FixInfo>();
#pragma warning restore IDE0044 // Add readonly modifier

        #endregion

        #region Init and process Methods

        /// <summary>
        /// Init all class wide settings.
        /// </summary>
        /// <param name="dbContext">DawaReplicationDBContext instance.</param>
        /// <param name="tableList">A list of tables to process.</param>
        /// <param name="dawaApiUri">Typical 'https://dawa.aws.dk/' .</param>
        /// <param name="readTimeoutInSeconds">DAWA api timeout in seconds. Normally 300 seconds.</param>
        /// <param name="udtraekRowsMax">Max number of rows to read. When 0 all rows are read.</param>
        public static void InitSettings(DawaReplicationDBContext dbContext, List<string> tableList, string dawaApiUri, string dawaTestApiUri, int readTimeoutInSeconds, int udtraekRowsMax, int udtraekBulkSize, int dkStedDataStartPos, int dkStedBulkSize, int dbCommandTimeoutInSeconds, string tempDataFolderPath, bool activeFixes, string activeFixesListFileLocation, bool useMSApplicationInsights)
        {
            if (tableList == null)
            {
                throw new ArgumentNullException(nameof(tableList));
            }

            if (tableList == null && tableList.Count == 0)
            {
                throw new ArgumentNullException(nameof(tableList));
            }

            if (string.IsNullOrEmpty(dawaApiUri))
            {
                throw new ArgumentNullException(nameof(dawaApiUri));
            }

            if (string.IsNullOrEmpty(dawaTestApiUri))
            {
                throw new ArgumentNullException(nameof(dawaTestApiUri));
            }

            if (readTimeoutInSeconds == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(readTimeoutInSeconds));
            }

            if (udtraekBulkSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(udtraekBulkSize));
            }

            if (tempDataFolderPath == null)
            {
                throw new ArgumentNullException(nameof(tempDataFolderPath));
            }

            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            TableList = tableList;
            DawaApiUri = dawaApiUri.EndsWith("/") ? dawaApiUri : dawaApiUri + "/";
            DawaTestApiUri = dawaTestApiUri.EndsWith("/") ? dawaTestApiUri : dawaTestApiUri + "/";
            ReadTimeoutInSeconds = readTimeoutInSeconds;
            UdtraekRowsMax = udtraekRowsMax;
            UdtraekBulkSize = udtraekBulkSize;
            DKStedDataStartPos = dkStedDataStartPos;
            DKStedBulkSize = dkStedBulkSize;
            dbContext.Database.SetCommandTimeout(dbCommandTimeoutInSeconds);
            TempDataFolderPath = tempDataFolderPath.EndsWith(@"\") ? tempDataFolderPath : tempDataFolderPath + @"\";
            ActiveFixes = activeFixes;
            ActiveFixesListFileLocation = activeFixesListFileLocation;
            UseMSApplicationInsights = useMSApplicationInsights;

            if (ActiveFixes)
            {
                fixInfoList = FixInfo.FixInfoList(ActiveFixesListFileLocation);
            }
        }

        /// <summary>
        /// Process active tables liste in config file.
        /// </summary>
        /// <param name="mode">Udtraek or Update.</param>
        /// <param name="dawaProcessInfo">Latest id from Dawa.</param>
        public static void ProcessTables(EntityProcessMode mode, DawaProcessInfo dawaProcessInfo)
        {
            if (dawaProcessInfo == null)
            {
                throw new ArgumentNullException(nameof(dawaProcessInfo));
            }

            var entityTyperPath = AppDomain.CurrentDomain.BaseDirectory + "JOInformatik.DawaReplication.DataAccess.dll";
            var entityAssembly = System.Reflection.Assembly.LoadFile(entityTyperPath);

            foreach (var tableName in TableList)
            {
                if ((mode == EntityProcessMode.Dagi && !tableName.StartsWith("DAGI__")) || (mode != EntityProcessMode.Dagi && tableName.StartsWith("DAGI__")))
                {
                    // If Mode is Dagi we only process dagi tables!
                    continue;
                }

                var starttime = default(DateTime);
                Console.Write($"Processing {tableName}: ");
                try
                {
                    EntityStateHelper.SetEntityStateStart(DBContext, mode, tableName, dawaProcessInfo.Txid);
                    starttime = EntityStateHelper.SetEntityStateHistoryStart(DBContext, mode, tableName, dawaProcessInfo.Txid);
                }
                catch (Exception ex)
                {
                    if (!dawaProcessInfo.FailedTables.Contains(tableName))
                    {
                        dawaProcessInfo.FailedTables.Add(tableName);
                    }

                    var msg = $"Mode {mode}: Cannot SetEntityState {tableName}. Problem: {ex.Message}. Program will continue with next entity. ";
                    Logger?.Error(msg, ex);
                    Console.Write("\nERROR! " + msg);
                    continue;
                }

                int count = 0;
                try
                {
                    Type entityType = entityAssembly.GetType($"JOInformatik.DawaReplication.DataAccess.{tableName}");
                    count = (int)typeof(EntityManager)
                        .GetMethod(mode.ToString())
                        .MakeGenericMethod(entityType)
                        .Invoke(null, new object[] { dawaProcessInfo, starttime });
                    Console.WriteLine($"Count = {count}.");
                }
                catch (Exception ex)
                {
                    if (!dawaProcessInfo.FailedTables.Contains(tableName))
                    {
                        dawaProcessInfo.FailedTables.Add(tableName);
                    }

                    var exception = ex.InnerException ?? ex;
                    var message = exception.Message;
                    if (ex.InnerException != null && ex.InnerException is Newtonsoft.Json.JsonSerializationException)
                    {
                        message += " TIP: Try using FixList.csv file to set a valid value if was a 'value {null}' problem. The Path name is probaly the non-null database columnname.";
                    }

                    var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, tableName, false, dawaProcessInfo.Txid, 0, message);
                    EntityStateHelper.SetEntityStateHistoryDone(DBContext, tableName, false, starttime, finishtime, null, null, null, message);

                    var msg = $"Mode {mode}: Cannot process entity {tableName}. Problem: {message}. Program will continue with next entity. ";
                    Logger?.Error(msg, exception);
                    Console.Write("\nERROR! " + msg);
                }
            }
        }

        /// <summary>
        /// Get data from DAWA WebApi and bootload database.
        /// </summary>
        /// <param name="dawaProcessInfo">Latest id from Dawa.</param>
        /// <returns>Count of all inserted rows.</returns>
        /// <typeparam name="T">Any entity class in the JOInformatik.DawaReplication.DataAccess namespace.</typeparam>
        public static int Udtraek<T>(DawaProcessInfo dawaProcessInfo, DateTime starttime)
            where T : ReplicationBase
        {
            if (dawaProcessInfo == null)
            {
                throw new ArgumentNullException(nameof(dawaProcessInfo));
            }

            if (dawaProcessInfo.Txid < 1)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentOutOfRangeException(nameof(dawaProcessInfo.Txid));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            DBContext.ChangeTracker.AutoDetectChangesEnabled = false;

            var methodName = LoggingUtils.GetMethodName();
            string entityName = typeof(T).Name;
            Logger?.Info($"{methodName}: Processing entity {entityName}");

            var sql = $"TRUNCATE TABLE [{entityName}]";
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
            DBContext.Database.ExecuteSqlCommand(sql);
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
            var itemList = new List<T>();
            int counter = 0;

            // Always use "&noformat" for increased performance:
            using (var httpClient = new HttpClient())
            {
                var stream = httpClient.GetStreamAsync($"{(entityName.ToUpperInvariant().StartsWith("BBR_") ? DawaTestApiUri : DawaApiUri)}replikering/udtraek?entitet={entityName.ToLowerInvariant()}&txid={dawaProcessInfo.Txid}&noformat").Result;
                stream.ReadTimeout = ReadTimeoutInSeconds * 1000;
                using (var reader = new JsonTextReader(new StreamReader(stream)))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            if (reader.TokenType == JsonToken.StartObject)
                            {
                                T itemAsObject = JsonConvert.DeserializeObject<T>(JObject.Load(reader).ToString(Formatting.None));
                                itemAsObject.EntityTxid = dawaProcessInfo.Txid;
                                itemList.Add(itemAsObject);

                                counter += 1;
                                // Prevent memory overflow, insert some items to database and clear the list to make space for new items.
                                // TODO Ver 1.5 Variable Bulkinsert size depending on table.
                                if (itemList.Count % UdtraekBulkSize == 0)
                                {
                                    DBContext.BulkInsert(itemList);
                                    Logger?.Debug($"{methodName}: Bulk- Fetched: {counter}");
                                    itemList.Clear();
                                }

                                if (UdtraekRowsMax != 0 && counter >= UdtraekRowsMax)
                                {
                                    break;
                                }
                            }
                        }

                        Logger?.Info($"{methodName}: Total fetched: {counter}");
                        Logger?.Info($"{methodName}: Entity {entityName} time of completion: {DateTime.Now.ToShortTimeString()}");

                        DBContext.BulkInsert(itemList);
                        var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, true, dawaProcessInfo.Txid, counter);
                        EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, true, starttime, finishtime, 0, counter, 0);
                    }
                    catch (Exception ex)
                    {
                        var exception = ex.InnerException ?? ex;
                        var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, false, dawaProcessInfo.Txid, counter, exception.Message);
                        EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, false, starttime, finishtime, 0, null, null, exception.Message);
                        throw;
                    }
                }
            }

            return counter;
        }

        /// <summary>
        /// Get data from DAWA WebApi and update database.
        /// </summary>
        /// <param name="dawaProcessInfo">Latest id from Dawa.</param>
        /// <returns>Count of all deleted, inserted and updated rows.</returns>
        /// <typeparam name="T">Any entity class in the JOInformatik.DawaReplication.DataAccess namespace.</typeparam>
        public static int Update<T>(DawaProcessInfo dawaProcessInfo, DateTime starttime)
            where T : ReplicationBase
        {
            if (dawaProcessInfo == null)
            {
                throw new ArgumentNullException(nameof(dawaProcessInfo));
            }

            if (dawaProcessInfo.Txid < 1)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentOutOfRangeException(nameof(dawaProcessInfo.Txid));
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            var methodName = LoggingUtils.GetMethodName();
            string entityName = typeof(T).Name;
            Logger?.Info($"{methodName}: Processing entity {entityName}");
            var fixInfo = fixInfoList.Find(x => x.TableName == entityName);
            var listInsertOrUpdate = new List<T>();
            var listDelete = new List<T>();
            long txidfra = EntityStateHelper.GetTxid(DBContext, entityName).Value + 1;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Always use "&noformat" for increased performance:
            using (var httpClient = new HttpClient())
            {
                var stream = httpClient.GetStreamAsync($"{DawaApiUri}replikering/haendelser?entitet={entityName.ToLowerInvariant()}&txidfra={txidfra}&txidtil={dawaProcessInfo.Txid}&noformat").Result;
                stream.ReadTimeout = ReadTimeoutInSeconds * 1000;
                using (var reader = new JsonTextReader(new StreamReader(stream)))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var item = JObject.Load(reader);
                            var operation = item.Property("operation").Value.ToString();
                            if (operation != null && (operation == "update" || operation == "insert" || operation == "delete"))
                            {
                                var itemData = item.Property("data").First.ToString(Formatting.None);
                                if (fixInfo != null)
                                {
                                    itemData = itemData.Replace(fixInfo.DataValueBad, fixInfo.DataValueValid);
                                }

                                T itemAsObject = JsonConvert.DeserializeObject<T>(itemData);
                                itemAsObject.SetEntityFields(item);
                                switch (operation)
                                {
                                    case "insert":
                                    case "update":
                                        listInsertOrUpdate.Add(itemAsObject);
                                        break;

                                    case "delete":
                                        listDelete.Add(itemAsObject);
                                        break;
                                }
                            }
                            else
                            {
                                Logger?.Warn($"{methodName}: Unrecognized operation '{operation}' for {entityName}. Txid = {dawaProcessInfo.Txid}");
                            }
                        }
                    }
                }
            }

            UpdateEntityHelper.ProcessOperationLists(listDelete, listInsertOrUpdate);
            int deleteCount = listDelete.Count;
            int insertUpdateCount = listInsertOrUpdate.Count;

            if (insertUpdateCount == 0 && deleteCount == 0)
            {
                Logger?.Info($"{methodName}: {entityName}: No changes");
                var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, true, dawaProcessInfo.Txid, 0);
                EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, true, starttime, finishtime, txidfra, insertUpdateCount, deleteCount);
            }
            else
            {
                Logger?.Info($"{methodName}: {entityName}: Inserted and Updated = {insertUpdateCount}, Deleted={deleteCount}");
                int totalCount = insertUpdateCount + deleteCount;

                DBContext.Database.BeginTransaction();
                try
                {
                    DBContext.BulkInsertOrUpdate(listInsertOrUpdate);
                    DBContext.BulkDelete(listDelete);
                    var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, true, dawaProcessInfo.Txid, totalCount);
                    EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, true, starttime, finishtime, txidfra, insertUpdateCount, deleteCount);
                    DBContext.Database.CommitTransaction();

                    if (UseMSApplicationInsights)
                    {
                        TelemetryHelper.AddTelemetryForEntity(EntityProcessMode.Update, entityName, stopwatch);
                    }
                }
                catch (Exception ex)
                {
                    if (DBContext.Database.CurrentTransaction != null)
                    {
                        DBContext.Database.RollbackTransaction();
                    }

                    var exception = ex.InnerException ?? ex;
                    var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, false, txidfra, totalCount, exception.Message);
                    EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, false, starttime, finishtime, txidfra, null, null, exception.Message);
                    throw;
                }
            }

            return listInsertOrUpdate.Count + listDelete.Count;
        }

#pragma warning disable CA1801 // Remove unused parameter
#pragma warning disable IDE0060 // Remove unused parameter
        /// <summary>
        /// Get data from DAWA DAGI WebApi and bootload database.
        /// </summary>
        /// <param name="transactionInfo">Dummy - not used.</param>
        /// <returns>Count of all rows.</returns>
        /// <typeparam name="T">Any DAGI entity class in the JOInformatik.DawaReplication.DataAccess namespace.</typeparam>
        public static int Dagi<T>(DawaProcessInfo transactionInfo, DateTime starttime)
#pragma warning restore IDE0060 // Remove unused parameter
#pragma warning restore CA1801 // Remove unused parameter
            where T : DAGIBase
        {
            var methodName = LoggingUtils.GetMethodName();
            string entityName = typeof(T).Name;
            Logger?.Info($"{methodName}: Processing entity {entityName}");

            var entityNameApi = entityName.Substring(6).ToLowerInvariant();   // Get rid of starting "DAGI__"
            int counter = 0;
            var itemList = new List<T>();
            var syncDeletesTime = DateTime.Now;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            using (var httpClient = new HttpClient())
            {
                // Always use "&noformat" for increased performance:
                var stream = httpClient.GetStreamAsync($"{DawaApiUri}{entityNameApi}?format=geojson&srid={(int)KoordinatsystemSrid.ETRS89}&noformat").Result;
                stream.ReadTimeout = ReadTimeoutInSeconds * 1000;
                var fileStream = LocalDataHelper.CreateTempFile(entityName);
                try
                {
                    // Remove geojson header and save to file. Read from same file and stop when reaching end of array(list of objects).
                    for (int x = 0; x < DKStedDataStartPos; x++)
                    {
                        stream.ReadByte();
                    }

                    stream.CopyTo(fileStream);
                    stream.Close();
                    fileStream.Close();
                }
                catch
                {
                    // If something goes wrong, make sure to close filestream, so we can try to write to the file again.
                    stream.Close();
                    fileStream.Close();
                    throw;
                }
            }

            var fileLocation = LocalDataHelper.RenameTempFile(entityName);
            Console.Write("Done saving to file.");

            using (var reader = new JsonTextReader(new StreamReader(fileLocation)))
            {
                DBContext.Database.BeginTransaction();
                try
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.EndArray)
                        {
                            break;
                        }

                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var item = JObject.Load(reader);
                            T rootItemAsObject = JsonConvert.DeserializeObject<T>(item.ToString(Formatting.None));
                            T itemAsObject = JsonConvert.DeserializeObject<T>(item["properties"].ToString(Formatting.None));

                            itemAsObject.SetEntityFields(item);
                            itemAsObject.Geometry = rootItemAsObject.Geometry;
                            itemList.Add(itemAsObject);

                            counter += 1;

                            if (itemList.Count % DKStedBulkSize == 0)
                            {
                                DBContext.BulkInsertOrUpdate(itemList);
                                itemList.Clear();
                            }
                        }
                    }

                    Logger?.Info($"{methodName}: Total fetched: {counter}");

                    DBContext.BulkInsertOrUpdate(itemList);
                    DagiStedHelper.DeleteOldRows(DBContext, entityName, syncDeletesTime);

                    var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, true, -1, counter);
                    EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, true, starttime, finishtime, -1, itemList.Count, 0);
                    if (UseMSApplicationInsights)
                    {
                        TelemetryHelper.AddTelemetryForEntity(EntityProcessMode.Dagi, entityName, stopwatch);
                    }

                    DBContext.Database.CommitTransaction();

                }
                catch (Exception ex)
                {
                    if (DBContext.Database.CurrentTransaction != null)
                    {
                        DBContext.Database.RollbackTransaction();
                    }

                    var exception = ex.InnerException ?? ex;
                    var finishtime = EntityStateHelper.SetEntityStateDone(DBContext, entityName, false, -1, counter, exception.Message);
                    EntityStateHelper.SetEntityStateHistoryDone(DBContext, entityName, false, starttime, finishtime, -1, null, null, exception.Message);
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    throw;
                }

            }

            // Delete temporary file.
            LocalDataHelper.RemoveTempFile(fileLocation);

            return counter;
        }
    }
    #endregion
}
