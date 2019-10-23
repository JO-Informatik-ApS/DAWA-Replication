using JOInformatik.DawaReplication.DataAccess;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace JOInformatik.DawaReplication.Helpers
{
    public static class InitializeHelpers
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger("DawaReplication");

        /// <summary>
        /// Return a filled DawaProcessInfo class.
        /// </summary>
        /// <param name="processMode">From settings field EntityProcessMode.</param>
        /// <param name="dawaApiUri">From settings field DawaApiUri.</param>
        /// <param name="dawaApiReadTimeout">From settings field DawaApiReadTimeout.</param>
        /// <param name="txidOverride">From settings field TxidOverride.</param>
        /// <returns>Returns a filled DawaProcessInfo class.</returns>
        public static DawaProcessInfo MakeDawaProcessInfo(EntityProcessMode processMode, string dawaApiUri, int dawaApiReadTimeout, int txidOverride)
        {
            if (processMode == EntityProcessMode.Dagi)
            {
                return new DawaProcessInfo(-1);
            }

            if (txidOverride > 0)
            {
                return new DawaProcessInfo(txidOverride);
            }

            var txid = DawaTransactionHelper.GetLatestTransaction(dawaApiUri, dawaApiReadTimeout);
            return new DawaProcessInfo(txid);
        }

        /// <summary>Check if the program can establish a connection to the database.</summary>
        public static void HaltIfNoDBConnection()
        {
            try
            {
                using (var context = new DawaReplicationDBContext())
                {
                    // context.Entitystate.Max(t => t.Txid).GetValueOrDefault(0);
                    if (!context.Database.CanConnect())
                    {
                        var conn = ConfigurationManager.ConnectionStrings["DawaDatabase"].ConnectionString;
                        var msg = $"ERROR! Failed to connect to database. Check ConnectionString '{conn}' in config file and database user role.";
                        Console.WriteLine(msg);
                        _logger.Error($"Main(): {msg}");
                        Environment.Exit((int)ReturnCode.DBConnectionError);
                    }
                }
            }
            catch (Exception ex)
            {
                var conn = ConfigurationManager.ConnectionStrings["DawaDatabase"].ConnectionString;
                var msg = $"ERROR! Failed to connect to database. Check ConnectionString '{conn}' in config file and database user role. Problem: {ex.Message}";
                Console.WriteLine(msg);
                _logger.Error($"Main(): {msg}", ex);
                Environment.Exit((int)ReturnCode.DBConnectionError);
            }
        }

        /// <summary>Check if the program can establish a connection to the database.</summary>
        public static void HaltIfDBSchemeNotInitialized()
        {
            try
            {
                using (var context = new DawaReplicationDBContext())
                {
                    context.Entitystate.Max(t => t.Txid).GetValueOrDefault(0);
                }
            }
            catch (Exception ex)
            {
                var conn = ConfigurationManager.ConnectionStrings["DawaDatabase"].ConnectionString;
                var msg = $"ERROR! The database scheme has not been initialized. Check ConnectionString '{conn}' in config file and make sure the database is initialized. Problem: {ex.Message}";
                Console.WriteLine(msg);
                _logger.Error($"Main(): {msg}", ex);
                Environment.Exit((int)ReturnCode.DBConnectionError);
            }
        }

        /// <summary>Check if an instance of this program allready is running.</summary>
        public static void HaltIfAllreadyRunning()
        {
            var path = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(path)).Count() > 1)
            {
                Environment.Exit((int)ReturnCode.Success);
            }
        }
    }
}
