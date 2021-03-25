using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddressList
{
    /// <summary>
    /// When overridden, implements function to read and write single card files.
    /// </summary>
    public abstract class CardFormatter
    {
        public abstract Task ReadCardAsync(Card card, TextReader reader);
        public abstract Task WriteCardAsync(Card card, TextWriter writer);
    }
}
