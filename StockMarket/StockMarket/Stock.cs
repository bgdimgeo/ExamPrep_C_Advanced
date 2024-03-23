using System;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;
        public string CompanyName { get { return this.companyName; } set { this.companyName = value; } }
        public string Director { get { return this.director; } set { this.director = value; } }
        public decimal PricePerShare { get { return this.pricePerShare; } set { this.pricePerShare = value; } }
        public int TotalNumberOfShares { get { return this.totalNumberOfShares; } set { this.totalNumberOfShares = value; } }

        public decimal MarketCapitalization { get { return this.marketCapitalization; }  }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            this.marketCapitalization = PricePerShare * TotalNumberOfShares;

        }
        public override string ToString()
        {
            return $"Company: {CompanyName}" +
                 $"{Environment.NewLine}Director: {Director}" +
                 $"{Environment.NewLine}Price per share: ${PricePerShare:F2}" +
                 $"{Environment.NewLine}Market capitalization: ${MarketCapitalization:F2}";

        }
    }
}
