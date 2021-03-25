using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressList;

namespace AddressListTest
{
    [TestClass]
    public class TxtCardFormatterTest
    {
        [TestMethod]
        public void TestReadCardAsync()
        {
            var formatter = new TxtCardFormatter();
            var card = new Card();
            using (var infile = new StreamReader(@"../../../../../data/test/card_000.txt"))
            {
                var task = formatter.ReadCardAsync(card, infile);
                task.Wait();
            }

            Assert.AreEqual(1000, card.Id);
        }
    }
}
