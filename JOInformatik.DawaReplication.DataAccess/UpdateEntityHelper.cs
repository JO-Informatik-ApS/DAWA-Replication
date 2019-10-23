using System.Collections.Generic;
using System.Linq;

namespace JOInformatik.DawaReplication.DataAccess
{
    public static class UpdateEntityHelper
    {
        /// <summary>
        /// Remove all rows in listDelete which are "touched" in list listInsertUpdate at a later Txid.
        /// </summary>
        /// <returns>True if any list was changed.</returns>
        /// <typeparam name="T">Any class in the JOInformatik.DawaReplikeringsTyper namespace.</typeparam>
        public static bool ProcessOperationLists<T>(List<T> listDelete, List<T> listInsertUpdate)
            where T : ReplicationBase
        {
            var count = 0;
            count += RemoveDuplicates(listDelete);
            count += RemoveDuplicates(listInsertUpdate);
            var anyChanges = RemoveEarlierOperations(listDelete, listInsertUpdate);
            return count > 0 || anyChanges;
        }

        public static int RemoveDuplicates<T>(List<T> list)
            where T : ReplicationBase
        {
            int deleted = 0;
            if (list.Any())
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    if (list[i].EntityCrudOperation == EntityCrudOperation.Unknown)
                    {
                        continue;
                    }

                    for (int y = i; y > 0; y--)
                    {
                        if (list[i].DawaPkey == list[y - 1].DawaPkey)
                        {
                            list[y - 1].EntityCrudOperation = EntityCrudOperation.Unknown;
                            deleted++;
                        }
                    }
                }

                list.RemoveAll(t => t.EntityCrudOperation == EntityCrudOperation.Unknown);
            }

            return deleted;
        }

        public static bool RemoveEarlierOperations<T>(List<T> listDelete, List<T> listInsertUpdate)
            where T : ReplicationBase
        {
            bool anylistChanged = false;

            if (listInsertUpdate.Any() && listDelete.Any())
            {
                foreach (T entityDelete in listDelete)
                {
                    var entityInsertUpdate = listInsertUpdate.FirstOrDefault(f => f.DawaPkey == entityDelete.DawaPkey);
                    if (entityInsertUpdate != null)
                    {
                        if (entityDelete.EntityTxid > entityInsertUpdate.EntityTxid)
                        {
                            entityInsertUpdate.EntityCrudOperation = EntityCrudOperation.Unknown;
                            anylistChanged = true;
                        }
                        else
                        {
                            entityDelete.EntityCrudOperation = EntityCrudOperation.Unknown;
                            anylistChanged = true;
                        }
                    }
                }

                listInsertUpdate.RemoveAll(t => t.EntityCrudOperation == EntityCrudOperation.Unknown);
                listDelete.RemoveAll(t => t.EntityCrudOperation == EntityCrudOperation.Unknown);
            }

            return anylistChanged;
        }

    }
}
