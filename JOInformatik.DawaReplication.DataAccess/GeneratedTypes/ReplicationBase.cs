using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Replication base class used by Udtraek and Update.
    /// </summary>
    public class ReplicationBase : EntityBase
    {
        [Column("entity_txid")]
        [Required()]
        /// <summary>Txid fra haendelser (fra JSON).</summary>
        public long EntityTxid { get; set; }

        /// <summary>
        /// Fill field EntityTxid, EntityCrudOperation and EntityTidspunkt.
        /// </summary>
        /// <param name="item">JSON from http://dawa.aws.dk/replikering/haendelser?entitet=Xxx</param>
        public override void SetEntityFields(JObject item)
        {
            EntityTxid = int.Parse(item.Property("txid").Value.ToString());

            var operation = item.Property("operation").Value.ToString().ToLowerInvariant();
            switch (operation)
            {
                case "insert": EntityCrudOperation = EntityCrudOperation.Insert; break;
                case "update": EntityCrudOperation = EntityCrudOperation.Update; break;
                case "delete": EntityCrudOperation = EntityCrudOperation.Delete; break;
                default: throw new Exception($"Unknow operation mode {operation}");
            }
        }
    }
}
