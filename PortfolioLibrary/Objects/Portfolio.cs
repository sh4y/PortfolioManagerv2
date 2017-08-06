using System.Collections.Generic;

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