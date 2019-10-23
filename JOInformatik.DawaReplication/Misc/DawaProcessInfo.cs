using System.Collections.Generic;

namespace JOInformatik.DawaReplication.Helpers
{
    public class DawaProcessInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DawaProcessInfo"/> class.
        /// This constructor initializes the transaction ID.
        /// </summary>
        public DawaProcessInfo(int txid)
        {
            Txid = txid;
        }

        /// <summary>Gets the transaction id. Txid is the transaction ID for the json response from DAWA. In json the field is named txid, thus we keep it as convention.</summary>
        public int Txid { get; }

        /// <summary>
        /// Gets or sets a list of tables that was not uddated due to errors like timeout, "The connection was closed" etc.
        /// </summary>
        public List<string> FailedTables { get; set; } = new List<string>();
    }

}
