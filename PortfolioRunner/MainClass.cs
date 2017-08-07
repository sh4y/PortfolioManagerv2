using System;
using PortfolioLibrary;

namespace PortfolioRunner
{
    public class MainClass
    {
        public static void Main(String[] args)
        {
            DataManipulator dm = new DataManipulator();
            decimal[] closings = dm.GetListOfDailyClosingPrices("MS", 5);
            foreach (Decimal d in closings)
            {
                Console.WriteLine(d);
            }
            Console.Read();
        }
    }
}