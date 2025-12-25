namespace MainConstructor{
interface IsPrintable
{
    void Print();
}
class Report : IsPrintable
{
    public string? Title{get;set;}
    public void Print()
    {
        Console.WriteLine( $"Title is {Title}");
    }
}
}
