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

        private Dictionary<string, StockPosition> IndexedPositions = new Dictionary<string, StockPosition>();

        private List<string> listTickers = new List<string>();

        public void AddToPortfolio(StockPosition sp)
        {
            if (StockPortfolio == null)
                StockPortfolio = new List<StockPosition>();
            StockPortfolio.Add(sp);
            listTickers.Add(sp.GetTicker());
            IndexedPositions.Add(sp.GetTicker(), sp);
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
            if (IndexedPositions.ContainsKey(ticker))
            {
                foreach (StockPosition sp in GetStockPortfolio().ToArray())
                {
                    if (sp == IndexedPositions[ticker])
                    {
                        StockPortfolio.Remove(sp);
                        IndexedPositions.Remove(sp.GetTicker());
                        listTickers.Remove(sp.GetTicker());
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
            if (IndexedPositions.ContainsKey(getTicker))
            {
                StockPosition sp = new StockPosition(getTicker, newQty, getEntrancePrice);

                for (int i = 0; i < StockPortfolio.Count; i++)
                {
                    if (StockPortfolio[i] == IndexedPositions[getTicker])
                    {
                        StockPortfolio[i] = sp;
                        IndexedPositions[getTicker] = sp;
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