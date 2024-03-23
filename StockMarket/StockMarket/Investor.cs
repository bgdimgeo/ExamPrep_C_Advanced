using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {

        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public Investor( string fullName, string emailAddress, decimal moneyToInvest, string broker)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = broker;
            this.portfolio = new List<Stock>();
        }

        public string FullName { get { return this.fullName; } set { this.fullName = value; } }
        public string EmailAddress { get { return this.emailAddress; } set { this.emailAddress = value; } }
        public decimal MoneyToInvest { get { return this.moneyToInvest; } set { this.moneyToInvest = value; } }
        public string BrokerName { get { return this.brokerName; } set { this.brokerName = value; } }

        public int Count { get { return Portfolio.Count; } }
        public List<Stock> Portfolio { get { return this.portfolio; } }

        public void BuyStock(Stock stock) 
        {
            if (!Portfolio.Contains(stock)) 
            {
                if (stock.MarketCapitalization > 10000 && MoneyToInvest > stock.PricePerShare)
                {
                    Portfolio.Add(stock);
                    MoneyToInvest -= stock.PricePerShare;
                }
            }
            
        }
        public string SellStock(string companyName, decimal sellPrice) 
        {
            if (Portfolio.Any(x => x.CompanyName == companyName))
            {
                if (Portfolio.First(x => x.CompanyName == companyName).PricePerShare > sellPrice)
                {
                    return $"Cannot sell {companyName}.";
                }
                else 
                {
                    MoneyToInvest += sellPrice;
                    Portfolio.Remove(Portfolio.First(x => x.CompanyName == companyName));
                    return $"{companyName} was sold.";
                }
            }
            else 
            {
                return $"{companyName} does not exist.";
            }
        }
        public Stock FindStock(string companyName) 
        {
            return Portfolio.First(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count > 0)
            {
                List<Stock> orderedStocks = Portfolio.OrderByDescending(x => x.MarketCapitalization).ToList();
                return orderedStocks[0];
            }
            else 
            {
                return null;
            }
            
        }
        public string InvestorInformation() 
        {
            string returnValue = string.Empty;
            returnValue = $"The investor {FullName} with a broker {BrokerName} has stocks:";
            foreach (var kvp in Portfolio) 
            {
                returnValue += $"{Environment.NewLine}{kvp}";
            }
            return returnValue.Trim();
        }


    }
}
