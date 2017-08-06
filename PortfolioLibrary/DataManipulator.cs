using System;
using System.Collections.Generic;
using PortfolioLibrary.Objects;

namespace PortfolioLibrary
{
    public class DataManipulator
    {
        private static T[] Slice<T>(T[] source, int start, int end)
        {
            var len = end - start;

            // Return new array.
            var res = new T[len];
            for (var i = 0; i < len; i++)
                res[i] = source[i + start];
            return res;
        }

        public string[] GetRawData(string content)
        {
            var data = content.Split('\n');
            return Slice(data, 7, data.Length - 1);
        }

        public Dictionary<int, StockDataDay> GetDayInfoFromStrings(string[] data)
        {
            Dictionary<int, StockDataDay> pairs = new Dictionary<int, StockDataDay>();
            foreach (string line in data)
            {
                string[] info = line.Split(',');

                int vol, date;
                Decimal open, close, low, high;

                int.TryParse(info[StockDataConstants.Dateindex], out date);
                int.TryParse(info[StockDataConstants.Volumeindex], out vol);

                Decimal.TryParse(info[StockDataConstants.Closeindex], out close);
                Decimal.TryParse(info[StockDataConstants.Highindex], out high);
                Decimal.TryParse(info[StockDataConstants.Lowindex], out low);
                Decimal.TryParse(info[StockDataConstants.Openindex], out open);

                StockDataDay sdd = new StockDataDay(vol, open, low, high, close, date);

                pairs.Add(date, sdd);
            }

            return pairs;
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
    }
}