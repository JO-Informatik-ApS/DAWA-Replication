using JOInformatik.DawaReplication.Helpers.MSApplicationInsightsHelpers;
using System;
using System.Collections.Generic;

namespace JOInformatik.DawaReplication.Helpers
{
    public static class TelemetryHelper
    {
        public static void AddTime(string name, double time, string timeMeasure)
        {
            var signalSource = new Dictionary<string, string> { { "signalSource", name } };
            var processingTime = new Dictionary<string, double> { { "processingTime", time } };
            ApplicationInsightHelper.TelemetryClient.TrackEvent(
                $"{timeMeasure} taken to execute {name}", signalSource, processingTime);
        }

        public static void AddTelemetryForEntity(EntityProcessMode mode, string entityName, System.Diagnostics.Stopwatch stopwatch, bool inSeconds = true)
        {
            if (stopwatch == null)
            {
                throw new ArgumentNullException(nameof(stopwatch));
            }

            stopwatch.Stop();
            var signalSource = new Dictionary<string, string> { { "signalSource", entityName } };
            var processingTime = new Dictionary<string, double> { { "processingTime", inSeconds ? stopwatch.Elapsed.TotalSeconds : stopwatch.Elapsed.TotalMinutes } };
            ApplicationInsightHelper.TelemetryClient.TrackEvent(
                $"Mode {mode}: Number of {(inSeconds ? "seconds" : "minutes")} taken to process the remainder of {entityName}", signalSource, processingTime);
        }
    }
}