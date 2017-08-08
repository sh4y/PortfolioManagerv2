using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using PortfolioLibrary.Objects;

namespace PortfolioLibrary
{
    public class StockMath
    {
        public static Decimal Mean(Decimal[] arr)
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

        public static Decimal StandardDeviationPopulation(Decimal[] arr)
        {
            return (Decimal) Math.Sqrt((Double) new StockMath().VariancePopulation(arr));
        }

        //Exclude from code coverage as this has already been tested in StandardDeviationPopulation/VariancePopulation
        [ExcludeFromCodeCoverage]
        public static Decimal NDayVolatility(int n, StockPosition sp)
        {
            Decimal[] prices = new DataManipulator().GetListOfDailyClosingPrices(sp.GetTicker(), n);
            return StandardDeviationPopulation(prices);
        }

        public static Decimal VolatilityPriceChanges(Decimal[] arr)
        {
            Decimal[] changes = new decimal[arr.Length - 1];
            for (int i = 0; i < changes.Length -1; i++)
            {
                var change = arr[i + 1] - arr[i];
                change /= arr[i];
                changes[i] = change;
            }

            return Math.Round(StandardDeviationPopulation(changes), 3)*100;
        }

        public static Decimal VolatilityPriceChanges(StockPosition sp, int n)
        {
            Decimal[] closings = new DataManipulator().GetListOfDailyClosingPrices(sp.GetTicker(), n);
            return VolatilityPriceChanges(closings);
        }

        public static string FormattedVolatilityPriceChanges(Decimal[] arr)
        {
            return (VolatilityPriceChanges(arr)).ToString() + "%";
        }

        public static Decimal VolatilityPriceChangesFromTicker(string ticker, int n)
        {
            return VolatilityPriceChanges(new StockPosition(ticker, 0, 0), n);
        }

        public static string FormattedVolatilityPriceChangesFromTicker(string ticker, int n)
        {
            return VolatilityPriceChangesFromTicker(ticker, n).ToString(CultureInfo.InvariantCulture) + "%";
        }
    }
}
