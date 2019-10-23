using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__kommuner")]
    public partial class DAGI__Kommuner : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Kommuner()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// Unik ID.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("dagi_id", TypeName = "varchar(10)")]
        [Required()]
        public virtual string Dagi_id { get; set; }

        /// <summary>
        /// Kommunens myndighedskode. Er unik for hver kommune. 4 cifre.
        /// </summary>
        [Column("kode", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Kode { get; set; }

        /// <summary>
        /// Kommunens navn.
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
        /// Falsk angiver at kommunen er en ægte kommune med en folkevalgt forsamling. Sand angiver at området/kommunen hører under Forsvarministeriet.
        /// </summary>
        [Column("udenforkommuneinddeling")]
        [Required()]
        public virtual bool Udenforkommuneinddeling { get; set; }

        /// <summary>
        /// Regionens navn.
        /// </summary>
        [Column("regionsnavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Regionsnavn { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        /// Returns the primary key as a string (includes all columns).</summary>
        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Dagi_id.ToString();
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
