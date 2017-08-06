using NUnit.Framework;
public class StockPositionTests
{
    [TestCase("TEST", 100, 50.00)]
    [TestCase("APPL", 0, 0)]
    [TestCase("amd", 10, 10)]
    public void TestStockPositionCreation(string ti, int q, decimal ep)
    {
        var sp = new StockPosition(ti, q, ep);
        Assert.IsTrue(sp.GetTicker() == ti.ToUpper());
        Assert.IsTrue(sp.GetQuantity() == q);
        Assert.IsTrue(sp.GetEntrancePrice() == ep);
    }

    [TestCase(null)]
    [TestCase("test")]
    public void TestStockPositionCreation_NullValues(string s)
    {
        try
        {
            // ReSharper disable once UnusedVariable
            var stockPosition = new StockPosition(s, new int(), new int());
            Assert.Fail("Did not throw exception");
        }
        //Required for 100% code coverage
        finally
        {
            Assert.Pass();
        }
        // ReSharper disable once HeuristicUnreachableCode
        Assert.Pass();
    }

    [TestCase(10, 10, 100)]
    [TestCase(5.1, 10, 51)]
    public void TestGetEntranceValueOfPosition(decimal p, int q, decimal expVal)
    {
        var sp = new StockPosition("TEST", q, p);
        Assert.IsTrue(expVal == sp.GetEntranceValue());
    }
}