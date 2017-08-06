using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

public class DataManipulationTests
{
    public string[] MockData = {"0,50.04,51.04,49.04,49.54,1000", "1,70,80,60,65,2000"};

    [SetUp]
    public void init()
    {
    }

    [Test]
    public void TestRawDataSlice()
    {
        StringBuilder sb = new StringBuilder();
        List<String> arr = new List<String>();

        for (int i = 0; i < 15; i++)
        {
            sb.Append(i.ToString());
            if (i != 14)
            {
                sb.Append('\n');
            }
            //14 is neglected because the last line in doc is a blank
            if (i >= 7 && i != 14)
            {
                arr.Add(i.ToString());
            }
        }

        string[] result = new DataManipulator().GetRawData(sb.ToString());

        Assert.AreEqual(arr.ToArray(), result);
    }

    [TestCase(5000, 40.0, 30.0, 50.0, 45.0, 1)]
    public void TestCreateNewStockDataObject(int volume, Decimal open, Decimal low, Decimal high, Decimal close,
        int date)
    {
        StockDataDay sdd = new StockDataDay(volume, open, low, high, close, date);
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

