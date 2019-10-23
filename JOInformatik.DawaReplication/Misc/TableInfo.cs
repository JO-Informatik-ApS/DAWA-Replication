using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JOInformatik.DawaReplication.Helpers
{
    /// <summary>Describes an table entity and how it is processed.</summary>
    public class TableInfo
    {
        public TableInfo(string line)
        {
            Fill(line);
        }

        /// <summary>Gets or sets tablename.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets order for processing. Nr 1 gets processed first.</summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the table is should be processed.
        /// If false the table is skipped when processing.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>Reads the file with tableinfo and returns a list of TableInfo instances.</summary>
        /// <param name="path">The file to open for reading table info.</param>
        /// <param name="includeInactive">If false inactive tables are not returned in the list.</param>
        /// <returns>An ordered list of TableInfo instances</returns>
        public static List<TableInfo> GetTableInfoList(string path, bool includeInactive = false)
        {
            return File.ReadLines(path).Select(line => new TableInfo(line)).Where(t => includeInactive || t.Active).OrderBy(t => t.Order).ToList();
        }

        /// <summary>
        /// Read the line and fills all fields in the class.
        /// </summary>
        /// <param name="line">A string in format 'Name;Order;Enabled'.</param>
        public void Fill(string line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }

            string[] col = line.Split(';');

            if (col.Length >= 3)
            {
                Name = col[0].Trim();
                Order = int.Parse(col[1].Trim());
                Active = bool.Parse(col[2].Trim());
            }
        }
    }
}
