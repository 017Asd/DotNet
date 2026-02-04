using System;
using System.Data;
namespace MainConstructor
{
    public class Constructors
{
    public int Id{get;set;}
    public string? Name{get; set;}
    public string? requirement{get;set;}
    public string? LogHistory{get; set;}
    public Constructors()
    
    {
        LogHistory+=$"Object created on {DateTime.Now.ToString()}   {Environment.NewLine}";
        Console.WriteLine(LogHistory);
    }
    public Constructors(int id):this()  //this calls the empty constructor 
        {
            LogHistory+=$"Object created on {DateTime.Now.ToString()}   {Environment.NewLine}";
            this.Id=id;
        }
    public Constructors(int id, string name)
        {
            this.Id=id;
            
            this.Name=name;
            if (name.ToLower().Contains("idiot"))
                throw new ArgumentException("You idiot, dont type like this idiot");
            LogHistory+=$"Object created on {DateTime.Now.ToString()}   {Environment.NewLine}";
        }
    public Constructors(int id,string name,string Req):this()
        {
            this.Id=id;
            this.Name=name;
            this.requirement=Req;
            LogHistory+=$"Object created on {DateTime.Now.ToString()}   {Environment.NewLine}";
            Console.WriteLine(LogHistory);
        }

}
}
