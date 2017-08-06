namespace PortfolioLibrary.Objects
{
    public class StockDataDay
    {
        public StockDataDay(int volume, decimal open, decimal low, decimal high, decimal close, int date)
        {
            Volume = volume;
            Open = open;
            Low = low;
            High = high;
            Close = close;
            Date = date;
        }

        public int Date { get; }

        public decimal Close { get; }

        public decimal High { get; }

        public decimal Low { get; }

        public decimal Open { get; }

        public int Volume { get; }
    }
}