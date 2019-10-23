using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>Holds info about last Udtraek, Update or DAGI-load for all entities.</summary>
    [Table("entitystate")]
    public partial class Entitystate
    {
        /// <summary>
        /// Latest transaction id for entity. Set to null if Udtraek failed.
        /// </summary>   
        [Column("txid")]
        public long? Txid { get; set; }

        /// <summary>
        /// Entity name.
        /// </summary>
        [Key, Column("entity", TypeName = "varchar(200)")]
        [Required()]
        public string Entity { get; set; }

        /// <summary>
        /// Entity transaction state. Set to null when starting. Updated when finished with success (1) or failure (0).
        /// </summary>
        [Column("success")]
        public bool? Success { get; set; }

        /// <summary>
        /// The time success was set to true.
        /// </summary>
        [Column("successtime")]
        public DateTime? Successtime { get; set; }

        /// <summary>
        /// The time there was an actual change (count <> 0) with success.
        /// </summary>
        [Column("successtimeChange")]
        public DateTime? SuccesstimeChange { get; set; }

        /// <summary>
        /// Transaction start time.
        /// </summary>
        [Column("starttime")]
        public DateTime? Starttime { get; set; }

        /// <summary>
        /// Transaction finishing time. Set to null when starting and updated when finished.
        /// </summary>
        [Column("finishtime")]
        public DateTime? Finishtime { get; set; }

        /// <summary>
        /// Number of rows processed. Null if transaction didn't succeed.
        /// </summary>
        [Column("count")]
        public int? Count { get; set; }

        /// <summary>
        /// Error message if any. Null if none.
        /// </summary>
        [Column("message", TypeName = "varchar(max)")]
        public string Message { get; set; }

        [Column("monitoringIgnoreError")]
        public bool? MonitoringIgnoreError { get; set; }

    }
}
