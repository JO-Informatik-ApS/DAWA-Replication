using Microsoft.SqlServer.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Dagi base class with common fields for all DAGI tables.
    /// </summary>
    public class DAGIBase : EntityBase
    {
        [Column("ændret")]
        [Required()]
        /// <summary>Tidspunkt for seneste ændring registreret i DAWA. Opdateres ikke hvis ændringen kun vedrører geometrien (se felterne geo_ændret og geo_version).</summary>
        public virtual DateTime Ændret { get; set; }

        [Column("geo_ændret")]
        [Required()]
        /// <summary>Tidspunkt for seneste ændring af geometrien registreret i DAWA.</summary>
        public virtual DateTime Geo_ændret { get; set; }

        [Column("geo_version")]
        /// <summary>Versionsangivelse for geometrien. Inkrementeres hver gang geometrien ændrer sig i DAWA.</summary>
        public virtual int? Geo_version { get; set; }

        [Column("visueltcenter_x")]
        [Required()]
        /// <summary>Geometriens visuelle center X-koordinat. Kan eksempelvis anvendes til placering af labels.</summary>
        public virtual double Visueltcenter_x { get; set; }

        [Column("visueltcenter_y")]
        [Required()]
        /// <summary>Geometriens visuelle center Y-koordinat. Kan eksempelvis anvendes til placering af labels.</summary>
        public virtual double Visueltcenter_y { get; set; }

        [Column("geometry")]
        [Required()]
        [JsonConverter(typeof(SqlGeometryConverter))]
        /// <summary>Geometri. Et Point, Polygon, LineString, MultiPoint, MultiPolygon eller MultiLineString.</summary>
        public virtual SqlGeometry Geometry { get; set; }

        [Column("visueltcenter")]
        [Required()]
        /// <summary>Geometriens visuelle center som punkt med de givne x- og y-koordinater.</summary>
        public virtual SqlGeometry Visueltcenter { get; set; }

        /// <summary>
        /// Fill field EntityTidspunkt and Bbox.
        /// </summary>
        /// <param name="item">JSON from http://dawa.aws.dk/Xxxx?format=geojson&srid=25832&noformat/param>
        public override void SetEntityFields(JObject item)
        {
            Visueltcenter = CreateVisualCenter((double)item["properties"]["visueltcenter_x"], (double)item["properties"]["visueltcenter_y"]);
        }

        /// <summary>
        /// Sets the visual center field from given values.
        /// </summary>
        /// <param name="x">The x coordinate value.</param>
        /// <param name="y">The y coordinate value.</param>
        /// <returns>A point in a coordinate system as an SqlGeometry object.</returns>
        public static SqlGeometry CreateVisualCenter(double x, double y)
        {
            string wkt1 = "POINT(";
            wkt1 += x;
            wkt1 += $" {y})";
            SqlGeometry point = SqlGeometry.STGeomFromText(new SqlChars(new SqlString(wkt1)), (int)KoordinatsystemSrid.ETRS89);

            return point;
        }

    }

}
