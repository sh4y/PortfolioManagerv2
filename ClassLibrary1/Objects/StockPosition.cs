using System;

public class StockPosition
{
    private readonly decimal _entrancePrice;

    private readonly int _quantity;
    private readonly string _ticker;

    /// <summary>
    ///     Creates a StockPosition object
    /// </summary>
    /// <param name="tckr"></param>
    /// <param name="qty"></param>
    /// <param name="entrPrice"></param>
    public StockPosition(string tckr, int qty, decimal entrPrice)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
        // ReSharper disable once ConditionIsAlwaysTrueOrFalse

        _ticker = tckr ?? throw new NullReferenceException("Parameter is null");
        _quantity = qty;
        _entrancePrice = entrPrice;
    }

    public decimal GetEntranceValue()
    {
        return _entrancePrice * _quantity;
    }

    public string GetTicker()
    {
        return _ticker;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public decimal GetEntrancePrice()
    {
        return _entrancePrice;
    }
}