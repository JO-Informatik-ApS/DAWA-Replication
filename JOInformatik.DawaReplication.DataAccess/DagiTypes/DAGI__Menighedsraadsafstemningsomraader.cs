using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__menighedsraadsafstemningsomraader")]
    public partial class DAGI__Menighedsraadsafstemningsomraader : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Menighedsraadsafstemningsomraader()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// Dagi unik ID.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("dagi_id", TypeName = "varchar(10)")]
        [Required()]
        public virtual string Dagi_id { get; set; }

        /// <summary>
        /// Entity nummer. Heltal.
        /// </summary>
        [Column("nummer", TypeName = "varchar(10)")]
        [Required()]
        public virtual string Nummer { get; set; }

        /// <summary>
        /// Menighedsrådsafstemningsområdets navn.
        /// </summary>
        [Column("navn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>
        /// Kommunekoden. 4 cifre.
        /// </summary>
        [Column("kommunekode", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Kommunekode { get; set; }

        /// <summary>
        /// Kommunens navn.
        /// </summary>
        [Column("kommunenavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Kommunenavn { get; set; }

        /// <summary>
        /// Sognekoden. 4 cifre.
        /// </summary>
        [Column("sognekode", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Sognekode { get; set; }

        /// <summary>
        /// Sognets navn.
        /// </summary>
        [Column("sognenavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Sognenavn { get; set; }

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
