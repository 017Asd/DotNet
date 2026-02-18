namespace Q6
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public double CurrentPrice { get; set; }
        public double RiskFactor { get; set; }

        public Stock(string symbol, string companyName, double price, double riskFactor)
        {
            Symbol = symbol;
            CompanyName = companyName;
            CurrentPrice = price;
            RiskFactor = riskFactor;
        }
    }
}
