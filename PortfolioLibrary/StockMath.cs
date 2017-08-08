using System;
using System.Diagnostics.CodeAnalysis;
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
            return sum / arr.Length;
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

        public Decimal StandardDeviationPopulation(Decimal[] arr)
        {
            return (Decimal) Math.Sqrt((Double) VariancePopulation(arr));
        }

        //Exclude from code coverage as this has already been tested in StandardDeviationPopulation/VariancePopulation
        [ExcludeFromCodeCoverage]
        public Decimal NDayVolatility(int n, StockPosition sp)
        {
            Decimal[] prices = new DataManipulator().GetListOfDailyClosingPrices(sp.GetTicker(), n);
            return StandardDeviationPopulation(prices);
        }
    }
}
