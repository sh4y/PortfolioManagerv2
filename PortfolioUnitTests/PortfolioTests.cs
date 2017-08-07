using System;
using NUnit.Framework;
using PortfolioLibrary.Objects;

namespace PortfolioUnitTests
{
    public class PortfolioTests
    {
        [Test]
        public void TestCreationOfPortfolioWithCashBalance()
        {
            var p = new Portfolio();
            p.AddCashToPortfolio(666.66m);
            Assert.IsTrue(p.GetCashBalance() == 666.66m);
        }

        [Test]
        public void TestCreationOfPortfolioWithPreloadedCashBalance()
        {
            var p = new Portfolio(666.66m);
            Assert.IsTrue(p.GetCashBalance() == 666.66m);
        }

        [TestCase("APPL", 42, 151.44)]
        [TestCase("AAPL", 0, 141.0)]
        public void TestAddAndRemoveStockFromPortfolio(string tkr, int qty, decimal pr)
        {
            var sp = new StockPosition(tkr, qty, pr);
            var p = new Portfolio();
            
            //Test Add
            p.AddToPortfolio(sp);
            Assert.IsNotNull(p.GetStockPortfolio());
            Assert.IsTrue(p.GetStockPortfolio()[0].GetTicker() == tkr);
            Assert.IsTrue(p.GetStockPortfolio()[0].GetQuantity() == qty);
            Assert.IsTrue(p.GetStockPortfolio()[0].GetEntrancePrice() == pr);

            //Test Remove
            p.RemovePosition(sp.GetTicker());
            Assert.IsTrue(p.GetStockPortfolio().Count == 0);
        }

        [Test]
        public void TestRemovalOfStockNotInPortfolio()
        {
            var sp = new StockPosition("AAPL", 40, 140.0m);
            var p =  new Portfolio();
            p.AddToPortfolio(sp);
            try
            {
                p.RemovePosition("GOOG");
                Assert.Fail();
            }
            catch (NullReferenceException)
            {
                Assert.Pass();
            }
            Assert.Pass();
        }
    }
}