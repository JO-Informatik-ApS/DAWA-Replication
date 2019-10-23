using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__postnumre")]
    public partial class DAGI__Postnumre : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Postnumre()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// Unik identifikation af det postnummeret. Postnumre fastsættes af Post Danmark. Repræsenteret ved fire cifre. Eksempel: ”2400” for ”København NV”.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("nr", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Nr { get; set; }

        /// <summary>
        /// Det navn der er knyttet til postnummeret, typisk byens eller bydelens navn. Repræsenteret ved indtil 20 tegn. Eksempel: ”København NV”.
        /// </summary>
        [Column("navn", TypeName = "varchar(20)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>
        /// Stormodtager status
        /// </summary>
        [Column("stormodtager")]
        [Required()]
        public virtual bool Stormodtager { get; set; }

        /// <summary>
        /// Postnummerets unikke ID i DAGI. Heltal som string.
        /// </summary>
        [Column("dagi_id")]
        [Required()]
        public virtual int Dagi_id { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        /// Returns the primary key as a string (includes all columns).</summary>
        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Nr.ToString();
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
