using GeoJSON.Net.Contrib.MsSqlSpatial;
using GeoJSON.Net.Geometry;
using Microsoft.SqlServer.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Serialiserer mellem GeoJSON og type SqlGeometry.
    /// Kan også bruges med EF DbGeometry med using GeoJSON.Net.Contrib.EntityFramework;
    /// Mere info https://github.com/GeoJSON-Net/GeoJSON.Net.Contrib#wkt-conversion-examples
    /// </summary>
    public class SqlGeometryConverter : JsonConverter
    {
        // Eksempel:
        // [JsonConverter(typeof(SqlGeometryConverter))]
        // public SqlGeometry Position { get; set; }

        public override bool CanConvert(Type objectType)
        {
            return objectType.Equals(typeof(SqlGeometry));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return default(SqlGeometry);
            }

            var jObject = JObject.Load(reader);
            if (!jObject.HasValues)
            {
                return default(SqlGeometry);
            }

            var jobj = new JObject();
            if (jObject["$url"] != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var result = httpClient.GetStreamAsync(jObject["$url"].ToString()).Result;
                    using (var json = new StreamReader(new GZipStream(result, CompressionMode.Decompress)))
                    {
                        jobj = JObject.Parse(json.ReadToEnd());
                    }
                    if (!jobj.HasValues)
                    {
                        return default(SqlGeometry);
                    }
                }
            }
            else
            {
                jobj = jObject;
            }

            string type = jobj["type"].ToString().ToLowerInvariant();
            switch (type)
            {
                case "point":
                    return JsonConvert.DeserializeObject<Point>(jobj.ToString()).ToSqlGeometry((int)KoordinatsystemSrid.ETRS89);
                case "polygon":
                    return JsonConvert.DeserializeObject<Polygon>(jobj.ToString()).ToSqlGeometry((int)KoordinatsystemSrid.ETRS89);
                case "multilinestring":
                    return JsonConvert.DeserializeObject<MultiLineString>(jobj.ToString()).ToSqlGeometry((int)KoordinatsystemSrid.ETRS89);
                case "multipoint":
                    return JsonConvert.DeserializeObject<MultiPoint>(jobj.ToString()).ToSqlGeometry((int)KoordinatsystemSrid.ETRS89);
                case "multipolygon":
                    return JsonConvert.DeserializeObject<MultiPolygon>(jobj.ToString()).ToSqlGeometry((int)KoordinatsystemSrid.ETRS89);
                case "linestring":
                    return JsonConvert.DeserializeObject<LineString>(jobj.ToString()).ToSqlGeometry((int)KoordinatsystemSrid.ETRS89);
                default:
                    throw new Exception($"SqlGeometryConverter unknown type: {type}");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // More information https://github.com/GeoJSON-Net/GeoJSON.Net.Contrib#wkt-conversion-examples

            // For converting SqlGeometry/SqlGeography to geojson use the following: 
            // using GeoJSON.Net.Contrib.MsSqlSpatial;
            // Point point = simplePoint.ToGeoJSONObject<Point>();

            // For converting EntityFramework Geometry/Geography to geojson use the following
            // using GeoJSON.Net.Contrib.EntityFramework;
            // Point point = dbGeometryPoint.ToGeoJSONObject<Point>();

            var geo = value as SqlGeometry;
            serializer.Serialize(writer, value == null ? null : JsonConvert.SerializeObject(geo.ToGeoJSONGeometry()));
        }
    }
}
