public class StockDataDay
{
    private readonly int _date;
    private readonly decimal _close;
    private readonly decimal _high;
    private readonly decimal _low;
    private readonly decimal _open;
    private readonly int _volume;

    public StockDataDay(int volume, decimal open, decimal low, decimal high, decimal close, int date)
    {
        _volume = volume;
        _open = open;
        _low = low;
        _high = high;
        _close = close;
        _date = date;
    }

    public int Date
    {
        get { return _date; }
    }

    public decimal Close
    {
        get { return _close; }
    }

    public decimal High
    {
        get { return _high; }
    }

    public decimal Low
    {
        get { return _low; }
    }

    public decimal Open
    {
        get { return _open; }
    }

    public int Volume
    {
        get { return _volume; }
    }
}