using Microsoft.SqlServer.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace JOInformatik.DawaReplication.DataAccess
{
    [Table("dagi__afstemningsomraader")]
    public partial class DAGI__Afstemningsomraader : DAGIBboxBase
    {
        /// <summary>This constructor calls OnCreated().</summary>
        public DAGI__Afstemningsomraader()
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
        /// Afstemningsområdets nummer. Heltal.
        /// </summary>
        [Column("nummer", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Nummer { get; set; }

        /// <summary>
        /// Afstemningsområdets navn.
        /// </summary>
        [Column("navn", TypeName = "varchar(100)")]
        [Required()]
        public virtual string Navn { get; set; }

        /// <summary>
        /// Kommunens valg af afstmemningssted.
        /// </summary>
        [Column("afstemningsstednavn", TypeName = "varchar(100)")]
        [Required()]
        public virtual string Afstemningsstednavn { get; set; }

        /// <summary>
        /// Adgangsadressens unikke ID.
        /// </summary>
        [Column("afstemningsstedadresseid", TypeName = "varchar(36)")]
        [Required()]
        public virtual string Afstemningsstedadresseid { get; set; }

        /// <summary>
        /// Adressebetegnelse for adgangsadressen.
        /// </summary>
        [Column("afstemningsstedadressebetegnelse", TypeName = "varchar(100)")]
        [Required()]
        public virtual string Afstemningsstedadressebetegnelse { get; set; }

        /// <summary>
        /// Afstemningssteds adgangspunkts x-koordinat.
        /// </summary>
        [Column("afstemningssted_adgangspunkt_x")]
        [Required()]
        public virtual double Afstemningssted_adgangspunkt_x { get; set; }

        /// <summary>
        /// Afstemningssteds adgangspunkts y-koordinat.
        /// </summary>
        [Column("afstemningssted_adgangspunkt_y")]
        [Required()]
        public virtual double Afstemningssted_adgangspunkt_y { get; set; }

        /// <summary>
        /// Afstemningssteds adgangspunkts y-koordinat.
        /// </summary>
        [Column("afstemningssted_adgangspunkt")]
        [Required()]
        public virtual SqlGeometry Afstemningssted_adgangspunkt { get; set; }

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
        /// Opstillingskredsens unikke nummer.
        /// </summary>
        [Column("opstillingskredsnummer", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Opstillingskredsnummer { get; set; }

        /// <summary>
        /// Opstillingskredsens unikke navn.
        /// </summary>
        [Column("opstillingskredsnavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Opstillingskredsnavn { get; set; }

        /// <summary>
        /// Storkredsens unikke nummer.
        /// </summary>
        [Column("storkredsnummer", TypeName = "varchar(4)")]
        [Required()]
        public virtual string Storkredsnummer { get; set; }

        /// <summary>
        /// Storkredsens unikke navn.
        /// </summary>
        [Column("storkredsnavn", TypeName = "varchar(50)")]
        [Required()]
        public virtual string Storkredsnavn { get; set; }

        /// <summary>
        /// Valglandsdelens bogstav.
        /// </summary>
        [Column("valglandsdelsbogstav", TypeName = "varchar(1)")]
        [Required()]
        public virtual string Valglandsdelsbogstav { get; set; }

        /// <summary>
        /// Valglandsdelens navn.
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
                    _dawaPkey = Dagi_id.ToString();
                }
                return _dawaPkey;
            }
        }

        /// <summary>
        /// Fill the Bbox field.
        /// </summary>
        /// <param name="item">JSON from http://dawa.aws.dk/Xxxx?format=geojson&srid=25832&noformat/param>
        public override void SetEntityFields(JObject item)
        {
            base.SetEntityFields(item);
            Afstemningssted_adgangspunkt = CreateAdgangspunkt((double)item["properties"]["afstemningssted_adgangspunkt_x"], (double)item["properties"]["afstemningssted_adgangspunkt_y"]);
        }

        public static SqlGeometry CreateAdgangspunkt(double x, double y)
        {
            string wkt1 = "POINT(";
            wkt1 += x;
            wkt1 += $" {y})";
            SqlGeometry point = SqlGeometry.STGeomFromText(new SqlChars(new SqlString(wkt1)), (int)KoordinatsystemSrid.ETRS89);

            return point;
        }

        [Column("entity_updated")]
        [Required()]
        /// <summary>Tidspunktet da rækken blev oprettet eller ændret i databasen hos JOI.</summary>
        public virtual DateTime EntityUpdated { get; set; }
    }
}
