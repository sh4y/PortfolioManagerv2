using System.Collections.Generic;
using PortfolioLibrary.Objects;

namespace PortfolioLibrary
{
    public class DataManipulator : IDataManipulator
    {
        private static T[] Slice<T>(T[] source, int start, int end)
        {
            var len = end - start;
            if (len < 0)
            {
                return new T[0];
            }

            // Return new array.
            var res = new T[len];
            for (var i = 0; i < len; i++)
                res[i] = source[i + start];
            return res;
        }

        public string[] GetStockInfoArrayGivenRawString(string content)
        {
            var data = content.Split('\n');
            return Slice(data, 8, data.Length - 1);
        }

        public Dictionary<int, StockDataDay> GetDayInfoFromStrings(string[] data)
        {
            var pairs = new Dictionary<int, StockDataDay>();
            foreach (var line in data)
            {
                var info = line.Split(',');

                int vol, date;
                decimal open, close, low, high;

                int.TryParse(info[StockDataConstants.Dateindex], out date);
                int.TryParse(info[StockDataConstants.Volumeindex], out vol);

                decimal.TryParse(info[StockDataConstants.Closeindex], out close);
                decimal.TryParse(info[StockDataConstants.Highindex], out high);
                decimal.TryParse(info[StockDataConstants.Lowindex], out low);
                decimal.TryParse(info[StockDataConstants.Openindex], out open);

                var sdd = new StockDataDay(vol, open, low, high, close, date);

                pairs.Add(date, sdd);
            }

            return pairs;
        }

        private Dictionary<int, StockDataDay> GetDailyDataForTicker(string ticker, int n)
        {
            var content = new WebConnection().GetDailyStockDataFromTicker(ticker, n);
            var info = GetStockInfoArrayGivenRawString(content);
            return GetDayInfoFromStrings(info);
        }

        internal class StockDataConstants
        {
            public static int Dateindex = 0;
            public static int Closeindex = 1;
            public static int Highindex = 2;
            public static int Lowindex = 3;
            public static int Openindex = 4;
            public static int Volumeindex = 5;
        }

        #region Daily Getters

        public decimal[] GetListOfDailyClosingPrices(Dictionary<int, StockDataDay> pairs)
        {
            var arr = new List<decimal>();
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Close);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyClosingPrices(string ticker, int n)
        {
            var arr = new List<decimal>();
            var pairs = GetDailyDataForTicker(ticker, n);
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Close);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyOpeningPrices(Dictionary<int, StockDataDay> pairs)
        {
            var arr = new List<decimal>();
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Open);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyOpeningPrices(string ticker, int n)
        {
            var arr = new List<decimal>();
            var pairs = GetDailyDataForTicker(ticker, n);
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Open);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyHighPrices(Dictionary<int, StockDataDay> pairs)
        {
            var arr = new List<decimal>();
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.High);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyHighPrices(string ticker, int n)
        {
            var arr = new List<decimal>();
            var pairs = GetDailyDataForTicker(ticker, n);
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.High);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyLowPrices(Dictionary<int, StockDataDay> pairs)
        {
            var arr = new List<decimal>();
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Low);
            return arr.ToArray();
        }

        public decimal[] GetListOfDailyLowPrices(string ticker, int n)
        {
            var arr = new List<decimal>();
            var pairs = GetDailyDataForTicker(ticker, n);
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Low);
            return arr.ToArray();
        }

        public int[] GetListOfDailyVolume(Dictionary<int, StockDataDay> pairs)
        {
            var arr = new List<int>();
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Volume);
            return arr.ToArray();
        }

        public int[] GetListOfDailyVolume(string ticker, int n)
        {
            var arr = new List<int>();
            var pairs = GetDailyDataForTicker(ticker, n);
            foreach (var sdd in pairs.Values)
                arr.Add(sdd.Volume);
            return arr.ToArray();
        }

        #endregion
    }

    public interface IDataManipulator
    {
        string[] GetStockInfoArrayGivenRawString(string content);

        Dictionary<int, StockDataDay> GetDayInfoFromStrings(string[] data);

    }
}