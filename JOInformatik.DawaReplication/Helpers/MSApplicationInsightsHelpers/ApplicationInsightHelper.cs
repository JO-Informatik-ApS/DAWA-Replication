using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;

namespace JOInformatik.DawaReplication.Helpers.MSApplicationInsightsHelpers
{
    public static class ApplicationInsightHelper
    {
        public static TelemetryClient TelemetryClient => ApplicationInsightInitializer.TelemetryClient;
        public static bool IsInitialized => ApplicationInsightInitializer.TelemetryClient != null;

        public static void TrackException(string message, Exception exception)
        {
            TrackTrace(message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Error);
            TrackException(exception);
        }

        public static void TrackTraceInformation(string message)
        {
            TrackTrace(message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Information);
        }

        public static void TrackTraceWarning(string message)
        {
            TrackTrace(message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Warning);

        }

        public static void TrackTraceCritical(string message)
        {
            TrackTrace(message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Critical);
        }

        public static void TrackTraceVerbose(string message)
        {
            TrackTrace(message, Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Verbose);
        }

        public static void TrackTrace(string message, SeverityLevel severityLevel)
        {
            if (IsInitialized)
            {
                TelemetryClient.TrackTrace(message, severityLevel);
            }
        }
        public static void TrackException(Exception exception)
        {
            if (IsInitialized && exception != null)
            {
                TelemetryClient.TrackException(exception);
            }
        }

        public static void Flush()
        {
            if (IsInitialized)
            {
                TelemetryClient.Flush();
            }
        }
    }
}
