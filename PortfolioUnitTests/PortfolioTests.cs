using NUnit.Framework;

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

    [Test]
    public void TestAddStockToPortfolio()
    {
        var sp = new StockPosition("AAPL", 42, 151.44m);
        var p = new Portfolio();
        Assert.IsNull(p.GetStockPortfolio());
        p.AddToPortfolio(sp);
        Assert.IsNotNull(p.GetStockPortfolio());
        Assert.IsTrue(p.GetStockPortfolio()[0].GetTicker() == "AAPL");
        Assert.IsTrue(p.GetStockPortfolio()[0].GetQuantity() == 42);
        Assert.IsTrue(p.GetStockPortfolio()[0].GetEntrancePrice() == 151.44m);
    }
}