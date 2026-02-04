// #region 
// class Program
// {
//     public static void Main(){
//         Student obj=new Student();
//         obj.Rno=1;
//         obj.Name="Buffalo";
//         obj[0]="C";
//         obj[1]="C++";
//         obj[2]="C#";
//         Console.WriteLine("Roll: "+obj.Rno)   ;
//         Console.WriteLine("Second: "+obj.Name);
//         Console.WriteLine("Third: "+obj[2]);
//     }
// }
// #endregion
﻿namespace CheckNS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Checker checker=new Checker();
            checker.ID=20;
            checker.name="dd"; 
            //
            
            Console.WriteLine(checker.Addd());
            System.Xml.Serialization.XmlSerializer x=new System.Xml.Serialization.XmlSerializer(checker.GetType());
            x.Serialize(Console.Out,checker);
            Console.WriteLine();
            Console.ReadLine();

        }
    }


}