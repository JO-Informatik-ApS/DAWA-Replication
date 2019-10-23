using Microsoft.SqlServer.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace JOInformatik.DawaReplication.DataAccess
{
    public class DAGIBboxBase : DAGIBase
    {
        [JsonIgnore]
        [Column("bbox")]
        /// <summary>Geometriens bounding box, dvs. det mindste rectangel som indeholder geometrien. Består af et array af 4 tal. De første to tal er koordinaterne for bounding boxens sydvestlige hjørne, og to to sidste tal er koordinaterne for bounding boxens nordøstlige hjørne. Anvend srid parameteren til at angive det ønskede koordinatsystem.</summary>
        public virtual SqlGeometry Bbox { get; set; }

        /// <summary>
        /// Fill the Bbox field.
        /// </summary>
        /// <param name="item">JSON from http://dawa.aws.dk/Xxxx?format=geojson&srid=25832&noformat/param>
        public override void SetEntityFields(JObject item)
        {
            base.SetEntityFields(item);
            Bbox = BbMaker(item["bbox"]);
        }

        public static SqlGeometry BbMaker(JToken o)
        {
            if (o != null)
            {
                string wkt1 = "LINESTRING(";
                wkt1 += o[0].ToString();
                wkt1 += $" {o[1].ToString()}, ";
                wkt1 += o[2].ToString();
                wkt1 += $" {o[3].ToString()})";
                SqlGeometry bbox = SqlGeometry.STGeomFromText(new SqlChars(new SqlString(wkt1)), (int)KoordinatsystemSrid.ETRS89);

                return bbox.STEnvelope();
            }

            else
            {
                return null;
            }
        }
    }
}
