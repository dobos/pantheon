using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AddressList
{
    /// <summary>
    /// Implements function to write CSV files line by line
    /// </summary>
    public class CsvListFormatter : ListFormatter
    {
        private string separator;
        private string[] columns;

        public string Separator
        {
            get { return separator; }
            set { separator = value; }
        }

        public string[] Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public CsvListFormatter()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            this.separator = ",";
            this.columns = new string[0];
        }

        /// <summary>
        /// Write the columns names into the first line, quote strings.
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public override async Task WriteHeaderAsync(TextWriter writer)
        {
            var line = String.Empty;
            for (int i = 0; i < columns.Length; i++)
            {
                if (i > 0)
                {
                    line += separator;
                }
                line += QuoteString(columns[i]);
            }
            await writer.WriteLineAsync(line);
        }

        /// <summary>
        /// Write the fields of a single object, quote strings.
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public override async Task WriteFieldsAsync(IFields fields, TextWriter writer)
        {
            var line = String.Empty;
            var data = fields.GetFields();
            for (int i = 0; i < columns.Length; i++)
            {
                if (i > 0)
                {
                    line += separator;
                }
                line += QuoteString(data[columns[i]].ToString());
            }
            await writer.WriteLineAsync(line);
        }

        /// <summary>
        /// Does not do anything, CSV files have no footer.
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public override Task WriteFooterAsync(TextWriter writer)
        {
            // No op
            return Task.CompletedTask;
        }

        /// <summary>
        /// Double-quotes a string, doubles quotes inside
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string QuoteString(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
