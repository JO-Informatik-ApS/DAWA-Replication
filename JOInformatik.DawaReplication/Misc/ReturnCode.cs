namespace JOInformatik.DawaReplication.Helpers
{
    /// <summary>Codes returned to OS when the console application stops, fails or halts.</summary>
    public enum ReturnCode
    {
        /// <summary>The application ran without any problems</summary>
        Success = 0,

        /// <summary>The application halted with an unknow error/problem.</summary>
        UnknownError = 1,

        /// <summary>The application did not start because it could not initialize 'MS Application Insights'.</summary>
        ApplicationInsightInitializeError = 2,

        /// <summary>The application did not start because connection to the database could not be established.</summary>
        DBConnectionError = 3
    }
}
