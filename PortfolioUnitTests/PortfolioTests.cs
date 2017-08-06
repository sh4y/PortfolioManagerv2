using NUnit.Framework;
using PortfolioLibrary.Objects;

namespace PortfolioUnitTests
{
    public class PortfolioTests
    {
        [Test]
        public void TestCreationOfPortfolioWithCashBalance()
        {
            Portfolio p = new Portfolio();
            p.AddCashToPortfolio(666.66m);
            Assert.IsTrue(p.GetCashBalance() == 666.66m);
        }

        [Test]
        public void TestCreationOfPortfolioWithPreloadedCashBalance()
        {
            Portfolio p = new Portfolio(666.66m);
            Assert.IsTrue(p.GetCashBalance() == 666.66m);
        }

        [Test]
        public void TestAddStockToPortfolio()
        {
            StockPosition sp = new StockPosition("AAPL", 42, 151.44m);
            Portfolio p = new Portfolio();
            Assert.IsNull(p.GetStockPortfolio());
            p.AddToPortfolio(sp);
            Assert.IsNotNull(p.GetStockPortfolio());
            Assert.IsTrue(p.GetStockPortfolio()[0].GetTicker() == "AAPL");
            Assert.IsTrue(p.GetStockPortfolio()[0].GetQuantity() == 42);
            Assert.IsTrue(p.GetStockPortfolio()[0].GetEntrancePrice() == 151.44m);

        }
    }
}
