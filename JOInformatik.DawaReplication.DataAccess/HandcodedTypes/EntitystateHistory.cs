using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>Holds info about last Udtraek, Update or DAGI-load for all entities.</summary>
    [Table("entitystatehistory")]
    public partial class EntitystateHistory
    {
        /// <summary>
        /// Latest transaction id for entity. Set to null if Udtraek failed.
        /// </summary>   
        [Column("txidFra")]
        public long? TxidFra { get; set; }

        /// <summary>
        /// Latest transaction id for completed entity update.
        /// </summary>
        [Column("txidTil")]
        public long? TxidTil { get; set; }

        /// <summary>
        /// Entity name.
        /// </summary>
        [Key, Column("entity", TypeName = "varchar(200)", Order = 0)]
        [Required()]
        public string Entity { get; set; }

        /// <summary>
        /// Entity transaction state. Set to null when starting. Updated when finished with success (1) or failure (0).
        /// </summary>
        [Column("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// Transaction start time.
        /// </summary>
        [Key, Column("starttime", Order = 1)]
        public DateTime Starttime { get; set; }

        /// <summary>
        /// Transaction finishing time.
        /// </summary>
        [Column("finishtime")]
        public DateTime? Finishtime { get; set; }

        /// <summary>
        /// Number of rows processed. Null if transaction didn't succeed.
        /// </summary>
        [Column("insertupdatecount")]
        public int? InsertUpdateCount { get; set; }

        /// <summary>
        /// Number of rows processed. Null if mode is NOT update.
        /// </summary>
        [Column("deletecount")]
        public int? DeleteCount { get; set; }

        /// <summary>
        /// Error message if any. Null if none.
        /// </summary>
        [Column("message", TypeName = "varchar(max)")]
        public string Message { get; set; }

    }
}
