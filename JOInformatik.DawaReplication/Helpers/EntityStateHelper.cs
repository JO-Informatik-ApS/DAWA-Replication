using JOInformatik.DawaReplication.DataAccess;
using System;
using System.Linq;

namespace JOInformatik.DawaReplication.Helpers
{
    /// <summary>
    /// EntityState table helper class.
    /// </summary>
    public static class EntityStateHelper
    {
        /// <summary>
        /// GetTxid for last for Entity to create a new search query.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="entity">Name of the entity worked on.</param>
        /// <returns>int transaction ID.</returns>
        public static long? GetTxid(DawaReplicationDBContext dbContext, string entity)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return dbContext.Entitystate.Single(c => c.Entity == entity.ToLower()).Txid;
        }

        /// <summary>
        /// Create a new row in Entitystate for given entity.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        /// <param name="mode">EntityProcessMode. Udtraek/Update/Dagi.</param>
        /// <param name="entity">Entity name.</param>
        /// <param name="txid">Transaction ID.</param>
        public static void SetEntityStateStart(DawaReplicationDBContext dbContext, EntityProcessMode mode, string entity, long txid)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = entity.ToLower();

            // Create entity if missing:
            if (!dbContext.Entitystate.Any(c => c.Entity == entity))
            {
                var entitystate = new Entitystate
                {
                    Entity = entity,
                };
                dbContext.Add(entitystate);
                dbContext.SaveChanges();
            }

            var row = dbContext.Entitystate.Single(c => c.Entity == entity);
            row.Txid = mode == EntityProcessMode.Update ? row.Txid : txid;
            row.Success = null;
            row.Successtime = null;
            row.SuccesstimeChange = row.SuccesstimeChange;
            row.Starttime = DateTime.Now;
            row.Finishtime = null;
            row.Count = null;
            row.Message = null;

            dbContext.Update(row);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Set EntityState row for entity to complete.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        /// <param name="entity">Entity name.</param>
        /// <param name="success">Bool success.</param>
        /// <param name="txid">Transaction ID.</param>
        /// <param name="count">Items processed.</param>
        /// <param name="message">Error message if success = 0.</param>
        /// <returns>DateTime finishtime to synchronize EntityState rows with EntityStateHistory´.</returns>
        public static DateTime SetEntityStateDone(DawaReplicationDBContext dbContext, string entity, bool success, long? txid, int? count, string message = null)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var finishtime = DateTime.Now;
            var row = dbContext.Entitystate.Single(c => c.Entity == entity.ToLower());

            row.Txid = success ? txid : row.Txid;
            row.Success = success;
            row.Successtime = success ? finishtime : row.Successtime;
            row.SuccesstimeChange = success && count.GetValueOrDefault() > 0 ? finishtime : row.SuccesstimeChange;
            row.Finishtime = finishtime;
            row.Count = count;
            row.Message = message;
            row.MonitoringIgnoreError = row.MonitoringIgnoreError == false || row.MonitoringIgnoreError == null ? false : true;
            dbContext.Update(row);
            dbContext.SaveChanges();

            return finishtime;
        }

        /// <summary>
        /// Create row in EntityStateHistory table for current transaction.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        /// <param name="mode">EntityProcessMode mode. Udtraek/Update/DAGI.</param>
        /// <param name="entity">Entity name.</param>
        /// <param name="txidTil">Transaction ID for updating the table up to.</param>
        /// <returns>DateTime to synchronize between EntityState tables.</returns>
        public static DateTime SetEntityStateHistoryStart(DawaReplicationDBContext dbContext, EntityProcessMode mode, string entity, long? txidTil)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = entity.ToLower();

            EntitystateHistory row = new EntitystateHistory
            {
                Entity = entity,
            };

            row.TxidFra = (mode == EntityProcessMode.Udtraek || mode == EntityProcessMode.Dagi) ? -1 : dbContext.EntitystateHistory.Where(c => c.Entity == entity && c.Success == true).OrderByDescending(c => c.Starttime).First().TxidTil;
            row.TxidTil = mode == EntityProcessMode.Dagi ? null : txidTil;
            row.Success = null;
            row.Starttime = DateTime.Now;
            row.Finishtime = null;
            row.InsertUpdateCount = null;
            row.DeleteCount = null;
            row.Message = null;

            dbContext.Add(row);
            dbContext.SaveChanges();

            return row.Starttime;
        }

        /// <summary>
        /// Updates an EntityStateHistory row after transaction is completed.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        /// <param name="entity">Entity name.</param>
        /// <param name="success">Bool success.</param>
        /// <param name="starttime">Start time.</param>
        /// <param name="finishtime">Time of completion.</param>
        /// <param name="txidFra">Updated entity from transaction Id txidFra.</param>
        /// <param name="insertUpdateCount">Inserted or updated row count.</param>
        /// <param name="deleteCount">Deleted row count.</param>
        /// <param name="message">Error message if success = 0.</param>
        public static void SetEntityStateHistoryDone(DawaReplicationDBContext dbContext, string entity, bool success, DateTime starttime, DateTime finishtime, long? txidFra, int? insertUpdateCount, int? deleteCount, string message = null)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            var row = dbContext.EntitystateHistory.Single(c => c.Entity == entity.ToLower() && c.Starttime == starttime);
            // var row = dbContext.EntitystateHistory.OrderByDescending(x => x.Starttime).Where(c => c.Entity == entity.ToLower()).First();
            row.TxidFra = success == true ? txidFra : row.TxidFra;
            row.Success = success;
            row.Finishtime = finishtime;
            row.InsertUpdateCount = success == true ? insertUpdateCount : null;
            row.DeleteCount = success == true ? deleteCount : null;
            row.Message = message;

            dbContext.Update(row);
            dbContext.SaveChanges();

        }

        /// <summary>
        /// Runs a cleanup job in the EntityStateHistory table, deleting old rows.
        /// </summary>
        /// <param name="days">Number of days after which rows should be deleted.</param>
        /// <returns>int number of deleted records.</returns>
        public static int CleanupOldEntityStateRecords(int days)
        {
            var retval = 0;
            using (var context = new DawaReplicationDBContext())
            {
                var oldRecords = context.EntitystateHistory.Where(c => (DateTime.Now - c.Starttime).TotalDays > days);
                retval = oldRecords.Count();
                context.EntitystateHistory.RemoveRange(oldRecords);
                context.SaveChanges();
            }

            return retval;
        }
    }
}
