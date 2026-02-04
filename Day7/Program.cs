#region MM
// using System;
// namespace BasicOfBasic
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             int n = 5;
//             Someclass someclass = new Someclass();
//             string result = someclass.SomeMethod(ref n);
//             Console.WriteLine(result);
//             int input1 = 3;
//             int input2 = 4;

//             Console.WriteLine($"input1 is {input1}");
//             Console.WriteLine($"input2 is {input2}");

//             int sum = someclass.SomeMethod(ref input1, ref input2);
//             Console.WriteLine($"Sum with two parameter {sum}");

//             //ref is used to pass the parameter by reference
//             //it means any changes made to the parameter inside the method will be reflected outside the method
//             //the original value of the parameter will be changed
//             //its pointing to the original memory location of the variable

//             Console.WriteLine($"input1 is {input1}");
//             Console.WriteLine($"input2 is {input2}");
//         }
//     }    public class Someclass
//     {
//         public string SomeMethod(ref int n)
//         {
//             return $"Method with some parameter called { n }";
//         }
//         public int SomeMethod(ref int a,ref int b)
//         {
//             int n = a + b;
//             a = 100;
//             b = 200;
//             return n;
//         }
//     }
// }
#endregion
using System;
using Scenario;
namespace Scenario
{
    public class Program
    {
    public static void Main(string[] args)
        {
            Scenario.FlipKey 

        }
    }
}