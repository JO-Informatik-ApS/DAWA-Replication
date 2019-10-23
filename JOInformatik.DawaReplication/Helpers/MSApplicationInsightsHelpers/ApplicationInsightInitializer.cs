using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace JOInformatik.DawaReplication.Helpers.MSApplicationInsightsHelpers
{
    public static class ApplicationInsightInitializer
    {
        public static TelemetryClient TelemetryClient { get; set; } = null;
        /// <summary>
        /// fortæller om Unitialize er blevet kaldt.
        /// </summary>
        internal static bool IsInitialized { get; set; } = false;

        private static bool? _isTelemetryDisabled = null;

        /// <summary>
        /// Sætter application insight op
        /// Henter opsætning fra config filens appsettings
        /// Dawa_InsightKey
        /// Dawa_CloudRoleName
        /// </summary>
        public static void Initialize()
        {

            var cloudRoleName = ConfigurationManager.AppSettings["Dawa_CloudRoleName"];
            Initialize(cloudRoleName);

        }

        /// <summary>
        /// Sætter application insight op
        /// Henter opsætning fra config filens appsettings
        /// Dawa_InsightKey
        /// </summary>
        public static void Initialize(string cloudRoleName)
        {

            var instrumentationKey = ConfigurationManager.AppSettings["Dawa_InsightKey"];
            Initialize(instrumentationKey, cloudRoleName);
        }


        private static bool IsTelemetryDisabled()
        {
            return _isTelemetryDisabled ?? new[] { "true", "1", "ja" }.Contains(ConfigurationManager.AppSettings["Dawa_DisableTelemetry"], StringComparer.OrdinalIgnoreCase);
        }

        public static void Initialize(string instrumentationKey, string cloudRoleName, bool? isDisabled)
        {
            _isTelemetryDisabled = isDisabled;
            Initialize(instrumentationKey, cloudRoleName, false);
        }

        /// <summary>
        /// Sætter application insight op
        /// </summary>
        public static void Initialize(string instrumentationKey, string cloudRoleName)
        {

            if (IsTelemetryDisabled())
            {
                TelemetryConfiguration.Active.DisableTelemetry = true;
                TelemetryConfiguration.Active.InstrumentationKey = string.Empty;
                return;
            }
            if (IsInitialized)
            {
                throw new Exception("ApplicationInsight already initialized");
            }

            if (string.IsNullOrWhiteSpace(instrumentationKey))
            {
                throw new ArgumentNullException(nameof(instrumentationKey), "Supply valid input, add [Dawa_InsightKey] to appSettings or add [Dawa_DisableTelemetry] with value 'true' to appSettings to disable telemery");
            }

            if (string.IsNullOrWhiteSpace(cloudRoleName))
            {
                throw new ArgumentNullException(nameof(cloudRoleName), "Supply valid input, add [Dawa_CloudRoleName] to appSettings or add [Dawa_DisableTelemetry] with value 'true' to appSettings to disable telemery");
            }
            TelemetryConfiguration.Active.DisableTelemetry = false;
            TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;
            if (!TelemetryConfiguration.Active.TelemetryInitializers.Any(a => a as ConsoleTelemetryInitializer != null))
            {
                TelemetryConfiguration.Active.TelemetryInitializers.Add(new ConsoleTelemetryInitializer(cloudRoleName));
            }

            TelemetryClient = new TelemetryClient();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(FlushAndWait);

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            IsInitialized = true;
        }

        /// <summary>
        /// Fjerner application insight
        /// </summary>
        public static void Remove()
        {
            if (!IsInitialized)
            {
                throw new Exception("ApplicationInsight not initialized");
            }

            FlushAndWait(null, null);

            TelemetryConfiguration.Active.InstrumentationKey = string.Empty;
            TelemetryConfiguration.Active.DisableTelemetry = true;

            var initializer = TelemetryConfiguration.Active.TelemetryInitializers.FirstOrDefault(a => a as ConsoleTelemetryInitializer != null);
            if (initializer != null)
            {
                TelemetryConfiguration.Active.TelemetryInitializers.Remove(initializer);
            }

            AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            AppDomain.CurrentDomain.ProcessExit -= new EventHandler(FlushAndWait);

            TaskScheduler.UnobservedTaskException -= TaskScheduler_UnobservedTaskException;

            IsInitialized = false;
        }

        /// <summary>
        /// Sørger for at flushe log til application insight. Venter 5000 millisekunder for at sikre alt bliver afleveret.
        /// Bør altid kaldes før stop af applikationen.
        /// </summary>
        /// <returns></returns>
        private static void FlushAndWait(object sender, EventArgs e)
        {
            if (!IsInitialized)
            {
                return;
            }

            TelemetryClient?.Flush();
            log4net.LogManager.Flush(1000);
            Task.Delay(5000).Wait();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ApplicationInsightHelper.TrackException("UnhandledException detected.", ex);
            }
            else
            {
                ApplicationInsightHelper.TrackException("UnhandledException detected. (The ExceptionObject was not a Exception)", new Exception("The ExceptionObject was not a Exception, dont know what went wrong."));
            }
            FlushAndWait(sender, e);
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            ApplicationInsightHelper.TrackException("TaskScheduler_UnobservedTaskException", e.Exception);
        }

    }
}
