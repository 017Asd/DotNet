using System;
namespace CheckNS
{

    public  partial class Checker{
        public int ID{get;set;}
        public string Name{get;set;}
        public List<int> Scores;
        // public int Addd()
        // {
        //     return ID+Name;
        // }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            // Checker checker=new Checker();
            // checker.ID=20;
            // checker.Name="dd";
            // checker.Scores=new List<int> {90,80,70};
            
            // // Console.WriteLine(checker.Addd());
            // // System.Xml.Serialization.XmlSerializer x=new System.Xml.Serialization.XmlSerializer(checker.GetType());
            // System.Json.Serialization.JsonSerializer x=new System.Xml.Serialization.XmlSerializer(checker.GetType());
            // x.Serialize(Console.Out,checker);
            // Console.WriteLine();
            
    

        }
}

}
