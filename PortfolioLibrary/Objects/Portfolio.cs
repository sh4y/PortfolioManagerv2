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

        private List<string> listTickers = new List<string>();
        //TODO: Remove From Portfolio

        //TODO: Edit Portfolio

        public void AddToPortfolio(StockPosition sp)
        {
            if (StockPortfolio == null)
                StockPortfolio = new List<StockPosition>();
            StockPortfolio.Add(sp);
            listTickers.Add(sp.GetTicker());
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
            if (listTickers.Contains(ticker))
            {
                var list = GetStockPortfolio().ToArray();
                foreach (StockPosition s in list)
                {
                    if (s.GetTicker() == ticker)
                    {
                        this.StockPortfolio.Remove(s);
                        this.listTickers.Remove(s.GetTicker());
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Ticker does not exist");
            }
        }
    }
}