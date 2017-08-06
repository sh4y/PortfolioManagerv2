using System;

namespace PortfolioLibrary.Objects
{
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
            if (tckr == null)
                throw new NullReferenceException();
            _ticker = tckr.ToUpper();
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
}