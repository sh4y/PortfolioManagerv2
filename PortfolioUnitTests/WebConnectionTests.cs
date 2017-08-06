using NUnit.Framework;

public class WebConnectionTests
{
    [Test]
    public void TestWebConnectionString()
    {
        var connStr = new WebConnection().CreateConnectionString("MS", 2, 60);
        var expOutput = "https://www.google.com/finance/getprices?i=60&p=2d&f=d,o,h,l,c,v&df=cpct&q=MS";
        Assert.IsTrue(connStr == expOutput);
    }

    [TestCase("http://www.sh4y.me/unittest", "Stub")]
    [TestCase("http://www.sh4y.me/test", WebConnection.InvalidUrlError)]
    public void TestDownloadPageContent(string url, string expOutput)
    {
        var content = new WebConnection().DownloadPageContent(url);
        Assert.AreEqual(content, expOutput);
    }
}