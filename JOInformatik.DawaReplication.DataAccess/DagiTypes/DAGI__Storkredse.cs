using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__storkredse")]
    public partial class DAGI__Storkredse : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Storkredse()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// Storkredsens nummer. Heltal. Udgør nøglen.
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("nummer", TypeName = "varchar(10)")]
        [Required()]
        public virtual string Nummer { get; set; }

        /// <summary>
        /// Storkredsens navn.
        /// </summary>
        [Column("navn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>
        /// Regionskoden. 4 cifre.
        /// </summary>
        [Column("regionskode", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Regionskode { get; set; }

        /// <summary>
        /// Regionens navn.
        /// </summary>
        [Column("regionsnavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Regionsnavn { get; set; }

        /// <summary>
        /// Valglandsdelens bogstav.
        /// </summary>
        [Column("valglandsdelsbogstav", TypeName = "varchar(1)")]
        [Required()]
        public virtual string Valglandsdelsbogstav { get; set; }

        /// <summary>
        /// Valglandsdelens navn
        /// </summary>
        [Column("valglandsdelsnavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Valglandsdelsnavn { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        /// Returns the primary key as a string (includes all columns).</summary>
        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Nummer.ToString();
                }
                return _dawaPkey;
            }
        }

        [Column("entity_updated")]
        [Required()]
        /// <summary>Tidspunktet da rækken blev oprettet eller ændret i databasen hos JOI.</summary>
        public virtual DateTime EntityUpdated { get; set; }
    }
}
