using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__landsdele")]
    public partial class DAGI__Landsdele : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Landsdele()
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
        /// Afstemningsområdets navn.
        /// </summary>
        [Column("navn", TypeName = "varchar(100)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>
        /// Kommunens valg af afstmemningssted.
        /// </summary>
        [Column("nuts3", TypeName = "varchar(5)")]
        [Required()]
        public virtual string Nuts3 { get; set; }

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
