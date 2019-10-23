using JOInformatik.DawaReplication.DataAccess;
using System;
using System.Linq;

namespace JOInformatik.DawaReplication.Helpers
{
    public static class DagiStedHelper
    {
        public static void DeleteOldRows(DawaReplicationDBContext dbContext, string name, DateTime date)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            switch (name)
            {
                case "steder":
                    dbContext.Dagi_Steder.RemoveRange(dbContext.Dagi_Steder.Where(c => c.EntityUpdated < date));
                    dbContext.SaveChanges();
                    break;
                case "stednavne":
                    dbContext.Dagi_Stednavne.RemoveRange(dbContext.Dagi_Stednavne.Where(c => c.EntityUpdated < date));
                    dbContext.SaveChanges();
                    break;
                default:
                    break;
            }
        }
    }
}
