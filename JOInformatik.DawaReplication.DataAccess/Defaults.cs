using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>Global default values used in the solution.</summary>
    public static class Defaults
    {
        /// <summary>9999-12-31: Means 'forever'. This value is used in many other JOI solutions.</summary>
        public static DateTime Registreringslut = new DateTime(9999, 12, 31);

        /// <summary>9999-12-31: Means 'forever'. This value is used in many other JOI solutions.</summary>
        public static DateTime Virkningslut = new DateTime(9999, 12, 31);
    }
}
