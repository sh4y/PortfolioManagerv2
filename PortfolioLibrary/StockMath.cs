using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioLibrary.Objects;

namespace PortfolioLibrary
{
    public class StockMath
    {
        public Decimal Mean(Decimal[] arr)
        {
            Decimal sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return (Decimal) sum / arr.Length;
        }

        public Decimal VariancePopulation(Decimal[] arr)
        {
            Decimal mean = Mean(arr);

            Decimal numerator = 0;

            foreach (Decimal p in arr)
            {
                Decimal diffSquared = (Decimal)Math.Pow((double)(p - mean), 2);
                numerator += diffSquared;
            }

            return numerator / (arr.Length);

        }

        public Decimal NDayVolatility(int n, StockPosition sp)
        {
            Decimal[] prices = new DataManipulator().GetListOfDailyClosingPrices(sp.GetTicker(), n);
            return VariancePopulation(prices);

        }
    }
}
