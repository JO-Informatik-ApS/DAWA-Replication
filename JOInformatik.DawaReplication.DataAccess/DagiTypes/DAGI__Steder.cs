using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Steder fra registeret Danske Stednavne.
    /// </summary>
    [Table("dagi__steder")]
    public partial class DAGI__Steder : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Steder()
        {
            EntityUpdated = DateTime.Now;
            OnCreated();
        }

        /// <summary>
        /// Unik Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Column("id", TypeName = "varchar(36)")]
        [Required()]
        public virtual string Id { get; set; }

        /// <summary>
        /// Stedets type, fx Bygning, Seværdighed, Vej, Idraetsanlæg, Vandløb, osv.
        /// </summary>
        [Column("hovedtype", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Hovedtype { get; set; }

        /// <summary>
        /// Undertype. Fx Bygning: Universitet/andenBygning/hal
        /// </summary>
        [Column("undertype", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Undertype { get; set; }

        /// <summary>
        /// Indbyggertal, integer.
        /// </summary>
        [Column("indbyggerantal")]
        public virtual int? Indbyggerantal { get; set; }

        /// <summary>
        /// Bebyggelseskode
        /// </summary>
        [Column("bebyggelseskode", TypeName = "varchar(50)")]
        public virtual string Bebyggelseskode { get; set; }

        /// <summary>
        /// Primærtnavn
        /// </summary>
        [Column("primærtnavn", TypeName = "varchar(100)")]
        public virtual string Primærtnavn { get; set; }

        /// <summary>
        /// Primærtnavnstatus
        /// </summary>
        [Column("primærnavnestatus", TypeName = "varchar(20)")]
        public virtual string Primærnavnestatus { get; set; }

        /// <summary>
        /// Brofast status
        /// </summary>
        [Column("brofast")]
        public virtual bool? Brofast { get; set; }

        /// <summary>Overwrite this method to do your own initialization of the entity.</summary>
        partial void OnCreated();

        public override string DawaPkey
        {
            get
            {
                if (_dawaPkey == null)
                {
                    _dawaPkey = Id.ToString();
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
