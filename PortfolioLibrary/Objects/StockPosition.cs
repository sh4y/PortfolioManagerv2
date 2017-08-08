using System;
using System.Runtime.CompilerServices;

namespace PortfolioLibrary.Objects
{
    public class StockPosition
    {
        private readonly decimal _entrancePrice;
        private decimal _currentPrice;
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
            _currentPrice = _entrancePrice;
        }
    #region Getters

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
    #endregion

        private void UpdateCurrentPrice()
        {
            decimal price = new DataManipulator().GetListOfDailyClosingPrices(GetTicker(), 2)[0];
            _currentPrice = price;
        }

        public Decimal GetCurrentPrice()
        {
            UpdateCurrentPrice();
            return _currentPrice;
        }

        public Decimal GetMarketValue()
        {       
            return GetCurrentPrice() * _quantity;
        }
    }
}