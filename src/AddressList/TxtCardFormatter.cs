using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AddressList
{
    /// <summary>
    /// Implements function to read and write Card files in TXT format.
    /// </summary>
    public class TxtCardFormatter : CardFormatter
    {
        public override async Task ReadCardAsync(Card card, TextReader reader)
        {
            card.Id = int.Parse(await reader.ReadLineAsync());
            card.Name = await reader.ReadLineAsync();
            card.Address = await reader.ReadLineAsync();
        }

        public override Task WriteCardAsync(Card card, TextWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
