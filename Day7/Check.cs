namespace Scenario
{
    public class Check
    {
        public static void Main(string[] args)
        {
            FlipKey flipKey=new FlipKey();
            Console.WriteLine("Take input");
            string? input=Console.ReadLine();
            Console.WriteLine(flipKey.IsValid(input));


        }
    }
}