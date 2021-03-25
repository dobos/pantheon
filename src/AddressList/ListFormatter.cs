using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AddressList
{
    /// <summary>
    /// When overridden, implements function to serialize IField objects into text file.
    /// </summary>
    public abstract class ListFormatter
    {
        public abstract Task WriteHeaderAsync(TextWriter writer);
        public abstract Task WriteFieldsAsync(IFields fields, TextWriter writer);
        public abstract Task WriteFooterAsync(TextWriter writer);
    }
}
