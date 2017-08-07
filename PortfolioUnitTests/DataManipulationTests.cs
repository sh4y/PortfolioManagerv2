using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PortfolioLibrary;
using PortfolioLibrary.Objects;

namespace PortfolioUnitTests
{
    public class DataManipulationTests
    {
        public static string[] MockData = {"0,50.04,51.04,49.04,49.54,1000", "1,70,80,60,65,2000"};

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void TestRawDataSlice()
        {
            var sb = new StringBuilder();
            var arr = new List<string>();

            for (var i = 0; i < 15; i++)
            {
                sb.Append(i.ToString());
                if (i != 14)
                    sb.Append('\n');
                //14 is neglected because the last line in doc is a blank
                if (i >= 8 && i != 14)
                    arr.Add(i.ToString());
            }

            var result = new DataManipulator().GetStockInfoArrayGivenRawString(sb.ToString());

            Assert.AreEqual(arr.ToArray(), result);
        }

        [TestCase(5000, 40.0, 30.0, 50.0, 45.0, 1)]
        public void TestCreateNewStockDataObject(int volume, decimal open, decimal low, decimal high, decimal close,
            int date)
        {
            var sdd = new StockDataDay(volume, open, low, high, close, date);
            Assert.AreEqual(5000, sdd.Volume);
            Assert.AreEqual(40.0, sdd.Open);
            Assert.AreEqual(30.0, sdd.Low);
            Assert.AreEqual(50.0, sdd.High);
            Assert.AreEqual(45.0, sdd.Close);
            Assert.AreEqual(1, sdd.Date);
        }

        [Test]
        public void TestGetDayinfoFromStrings()
        {
            var pairs = new DataManipulator().GetDayInfoFromStrings(MockData);
            Assert.AreEqual(2, pairs.Count);

            Assert.AreEqual(pairs[0].Volume, 1000);
            Assert.AreEqual(pairs[0].Open, 49.54);
            Assert.AreEqual(pairs[0].Close, 50.04);
            Assert.AreEqual(pairs[0].Date, 0);
            Assert.AreEqual(pairs[0].High, 51.04);
            Assert.AreEqual(pairs[0].Low, 49.04);

            Assert.AreEqual(pairs[1].Volume, 2000);
            Assert.AreEqual(pairs[1].Open, 65);
            Assert.AreEqual(pairs[1].Close, 70);
            Assert.AreEqual(pairs[1].Date, 1);
            Assert.AreEqual(pairs[1].High, 80);
            Assert.AreEqual(pairs[1].Low, 60);
        }
    }
}