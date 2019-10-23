using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace JOInformatik.DawaReplication.Helpers
{
    public static class DawaTransactionHelper
    {
        /// <summary>
        /// Get the latest transaction ID (senestetransaktion) from the DAWA database. Used for either downloading the latest snapshot or updating.
        /// </summary>
        /// <returns>Returns the DAWA transaction ID as a string.</returns>
        public static int GetLatestTransaction(string dawaApiUri, int readTimeout)
        {
            // Static API link for finding latest transaction
            using (var httpClient = new HttpClient())
            {
                var stream = httpClient.GetStreamAsync($"{dawaApiUri}replikering/senestetransaktion").Result;
                stream.ReadTimeout = readTimeout * 1000;
                var streamReader = new System.IO.StreamReader(stream);
                using (var reader = new JsonTextReader(streamReader))
                {
                    while (reader.Read())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var json = JObject.Load(reader);
                            return int.Parse(json.Property("txid").Value.ToString());
                        }
                    }
                }
            }

            return 0;
        }
    }

}
