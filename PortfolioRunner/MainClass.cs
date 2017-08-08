using System;
using PortfolioLibrary;
using PortfolioLibrary.Objects;

namespace PortfolioRunner
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            DataManipulator dm = new DataManipulator();
            decimal[] closings = dm.GetListOfDailyClosingPrices("AMD", 100);
            Console.WriteLine(StockMath.VolatilityPriceChanges(closings) + "%");
            Console.WriteLine(StockMath.FormattedVolatilityPriceChangesFromTicker("AMD", 100));
            Console.WriteLine(StockMath.FormattedVolatilityPriceChangesFromTicker("GS", 100));
            Console.Read();
        }
    }
}