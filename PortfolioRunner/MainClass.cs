using System;
using System.Globalization;
using PortfolioLibrary;
using PortfolioLibrary.Objects;

namespace PortfolioRunner
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            WebConnection wc = new WebConnection();
            string content = wc.GetDailyStockDataFromTicker("AMD", 10);
            DataManipulator dm = new DataManipulator();
            var arr = dm.GetStockInfoArrayGivenRawString(content);
            var pairs = dm.GetDayInfoFromStrings(arr);
            foreach (StockDataDay sdd in pairs.Values)
            {
                Console.WriteLine(sdd.Date);
            }
            Console.Read();
        }
    }
}