using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
public class DataManipulationTests
{

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
    public void TestCreateNewStockDataObject(int volume, Decimal open, Decimal low, Decimal high, Decimal close, int date)
    {
        StockDataDay sdd = new StockDataDay(volume, open, low, high, close, date);
        Assert.AreEqual(5000, sdd.Volume);
        Assert.AreEqual(40.0, sdd.Open);
        Assert.AreEqual(30.0, sdd.Low);
        Assert.AreEqual(50.0, sdd.High);
        Assert.AreEqual(45.0, sdd.Close);
        Assert.AreEqual(1, sdd.Date);
    }
}

