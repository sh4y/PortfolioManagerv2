using System;
using System.Collections.Generic;

namespace PortfolioLibrary.Objects
{
    public class Portfolio
    {
        public Portfolio()
        {
        }

        public Portfolio(decimal cashBalance)
        {
            CashBalance = cashBalance;
        }

        private decimal CashBalance { get; set; }
        private List<StockPosition> StockPortfolio { get; set; }

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private Dictionary<string, StockPosition> _indexedPositions = new Dictionary<string, StockPosition>();

        // ReSharper disable once CollectionNeverQueried.Local
        private readonly List<string> _listTickers = new List<string>();

        public void AddToPortfolio(StockPosition sp)
        {
            if (StockPortfolio == null)
                StockPortfolio = new List<StockPosition>();
            StockPortfolio.Add(sp);
            _listTickers.Add(sp.GetTicker());
            _indexedPositions.Add(sp.GetTicker(), sp);
        }

        public void AddCashToPortfolio(decimal amt)
        {
            CashBalance += amt;
        }

        public List<StockPosition> GetStockPortfolio()
        {
            if (StockPortfolio.Count == 0)
            {
                return new List<StockPosition>();
            }
            return StockPortfolio;
        }

        // ReSharper disable once UnusedMember.Local
        public decimal GetCashBalance()
        {
            return CashBalance;
        }

        public void RemovePosition(string ticker)
        {
            if (_indexedPositions.ContainsKey(ticker))
            {
                foreach (StockPosition sp in GetStockPortfolio().ToArray())
                {
                    if (sp == _indexedPositions[ticker])
                    {
                        StockPortfolio.Remove(sp);
                        _indexedPositions.Remove(sp.GetTicker());
                        _listTickers.Remove(sp.GetTicker());
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Ticker does not exist");
            }
        }

        public void EditPosition(string getTicker, int newQty, decimal getEntrancePrice)
        {
            if (_indexedPositions.ContainsKey(getTicker))
            {
                StockPosition sp = new StockPosition(getTicker, newQty, getEntrancePrice);

                for (int i = 0; i < StockPortfolio.Count; i++)
                {
                    if (StockPortfolio[i] == _indexedPositions[getTicker])
                    {
                        StockPortfolio[i] = sp;
                        _indexedPositions[getTicker] = sp;
                    }
                }

            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}