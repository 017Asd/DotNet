namespace Q6
{
    public class Investor
    {
        public int InvestorId { get; set; }
        public string Name { get; set; }
        public Portfolio Portfolio { get; set; }

        public Investor(int id, string name)
        {
            InvestorId = id;
            Name = name;
            Portfolio = new Portfolio();
        }
    }
}
