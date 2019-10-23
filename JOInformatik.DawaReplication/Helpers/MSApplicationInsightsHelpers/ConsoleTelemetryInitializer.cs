using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace JOInformatik.DawaReplication.Helpers.MSApplicationInsightsHelpers
{
    internal class ConsoleTelemetryInitializer : ITelemetryInitializer
    {
        private readonly string _cloudRoleName;

        /// <summary>Opretter en ny telemetri initializer.</summary>
        public ConsoleTelemetryInitializer(string cloudRoleName)
        {
            _cloudRoleName = cloudRoleName;
        }

        /// <summary>Initializere telemetrien.</summary>
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = _cloudRoleName;
        }
    }
}
