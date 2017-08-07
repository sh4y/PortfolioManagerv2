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

        //TODO: Remove From Portfolio

        //TODO: Edit Portfolio

        public void AddToPortfolio(StockPosition sp)
        {
            if (StockPortfolio == null)
                StockPortfolio = new List<StockPosition>();
            StockPortfolio.Add(sp);
        }

        public void AddCashToPortfolio(decimal amt)
        {
            CashBalance += amt;
        }

        public List<StockPosition> GetStockPortfolio()
        {
            return StockPortfolio;
        }

        // ReSharper disable once UnusedMember.Local
        public decimal GetCashBalance()
        {
            return CashBalance;
        }
    }
}