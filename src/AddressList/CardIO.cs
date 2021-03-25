using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AddressList
{
    /// <summary>
    /// Implements functions to read and write card files and card lists.
    /// </summary>
    public class CardIO
    {
        public static async IAsyncEnumerable<Card> ReadCardFilesAsync(CardFormatter formatter, string[] files)
        {
            foreach (var path in files)
            {
                using (var infile = new StreamReader(path))
                {
                    var card = new Card();
                    await formatter.ReadCardAsync(card, infile);
                    yield return card;
                }
            }
        }

        public static async Task WriteCardListAsync(ListFormatter formatter, TextWriter writer, IAsyncEnumerable<Card> cards)
        {
            await formatter.WriteHeaderAsync(writer);
            await foreach(var card in cards)
            {
                await formatter.WriteFieldsAsync(card, writer);
            }
            await formatter.WriteFooterAsync(writer);
        }
    }
}
