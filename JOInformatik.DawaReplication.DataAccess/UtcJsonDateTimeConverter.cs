using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace JOInformatik.DawaReplication.DataAccess
{
    /// <summary>
    /// Class to convert to and from UTC and Danish local time.
    /// To use it, add the following line just above the property definition.
    /// [JsonConverter(typeof(UtcJsonDateTimeConverter))]
    /// public DateTime xxx { get;set; }
    /// </summary>
    public class UtcJsonDateTimeConverter : DateTimeConverterBase
    {
        private const string DefaultDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFZ";

        /// <summary>
        /// Converts a local datetime to a UTC date.
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string text;

            if (value is DateTime dateTime)
            {
                text = dateTime.ToString(DefaultDateTimeFormat, CultureInfo.InvariantCulture);
            }
            else
            {
                throw new JsonSerializationException(
                    $"Unexpected value when converting date. Expected DateTime or DateTimeOffset, got {value.GetType()}.");
            }

            writer.WriteValue(text);
        }

        /// <summary>
        /// Converts a UTC date to local datetime.
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool nullable = objectType == typeof(DateTime?);
            if (reader.TokenType == JsonToken.Null)
            {
                if (!nullable)
                {
                    throw new JsonSerializationException($"Cannot convert null value to {objectType}.");
                }

                return null;
            }

            //if (reader.TokenType == JsonToken.Date)
            //{
            //    return reader.Value;
            //}
            //else 
            if (reader.TokenType != JsonToken.Date)
            {
                throw new JsonSerializationException($"Unexpected token parsing date. Expected String, got {reader.TokenType}.");
            }

            string date_text = reader.Value.ToString();

            if (string.IsNullOrEmpty(date_text) && nullable)
            {
                return null;
            }

            return DateTime.Parse(date_text, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }
    }
}
