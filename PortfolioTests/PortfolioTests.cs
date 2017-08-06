using NUnit.Framework;

namespace PortfolioLibrary
{
    public class PortfolioTests
    {
        [TestCase("TEST", 100, 50.00)]
        [TestCase("APPL", 0, 0)]
        public void TestStockPositionCreation(string ti, int q, decimal ep)
        {
            var sp = new StockPosition(ti, q, ep);
            Assert.IsTrue(sp.GetTicker() == ti);
            Assert.IsTrue(sp.GetQuantity() == q);
            Assert.IsTrue(sp.GetEntrancePrice() == ep);
        }
    }
}