using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__valglandsdele")]
    public partial class DAGI__Valglandsdele : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Valglandsdele()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// Valgslandsdelens bogstav, udgør nøglen.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("bogstav", TypeName = "varchar(1)")]
        [Required()]
        public virtual string Bogstav { get; set; }

        /// <summary>
        /// Valglandsdelens navn.
        /// </summary>
        [Column("navn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        /// Returns the primary key as a string (includes all columns).</summary>
        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Bogstav.ToString();
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
