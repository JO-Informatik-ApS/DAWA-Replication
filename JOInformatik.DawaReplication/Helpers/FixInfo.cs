using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JOInformatik.DawaReplication.Helpers
{
    /// <summary>Table/entity info to fix an unexpeted PROD problem with a bad data value.</summary>
    public class FixInfo
    {
        /// <summary>Constructor.</summary>
        public FixInfo(string line)
        {
            Fill(line);
        }

        /// <summary>Gets or sets database table name (aka entityName).</summary>
        public string TableName { get; set; }

        /// <summary>Gets or sets database column name.</summary>
        public string ColumnName { get; set; }

        /// <summary>Gets or sets problematic incomming data value.</summary>
        public string DataValueBad { get; set; }

        /// <summary>Gets or sets fixed data value to be saved in databse.</summary>
        public string DataValueValid { get; set; }

        public static List<FixInfo> FixInfoList(string activeFixesFileLocation)
        {
            if (activeFixesFileLocation == null)
            {
                throw new ArgumentNullException(nameof(activeFixesFileLocation));
            }

            if (activeFixesFileLocation.Equals("FixList.csv"))
            {
                activeFixesFileLocation = AppDomain.CurrentDomain.BaseDirectory + activeFixesFileLocation;
            }

            // Skip comments:
            var lines = File.ReadLines(activeFixesFileLocation).Where(t => !t.StartsWith("--")).ToList();
            // Get only active fixes - those ending with "true".
            return lines.Where(t => t.TrimEnd().EndsWith("true")).Select(line => new FixInfo(line)).ToList();
        }

        public void Fill(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            string[] col = line.Split(';');

            if (col.Length >= 5)
            {
                TableName = col[0].Trim();
                ColumnName = col[1].Trim();
                DataValueBad = col[2].Trim();
                DataValueValid = col[3].Trim();
            }
        }
    }
}