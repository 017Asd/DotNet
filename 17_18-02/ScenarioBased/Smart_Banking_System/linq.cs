// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace Q2
// {
//     public class LinqProgram
//     {
//         public static void Main()
//         {
//             List<BankAccount> accounts = new List<BankAccount>
//             {
//                 new SavingsAccount(101, "Rahul", 75000),
//                 new SavingsAccount(102, "Ritika", 120000),
//                 new CurrentAccount(103, "Aman", 40000),
//                 new CurrentAccount(104, "Rohit", 90000),
//                 new LoanAccount(105, "Sneha", 150000),
//                 new SavingsAccount(106, "Arjun", 30000),
//                 new CurrentAccount(107, "Raj", 60000),
//                 new SavingsAccount(108, "Meera", 85000),
//                 new LoanAccount(109, "Ramesh", 200000),
//                 new SavingsAccount(110, "Karan", 25000)
//             };

//             Console.WriteLine("===== ACCOUNTS WITH BALANCE > 50,000 =====");
//             var highBalance = accounts.Where(a => a.Balance > 50000);

//             foreach (var acc in highBalance)
//             {
//                 Console.WriteLine($"{acc.Name} - {acc.Balance}");
//             }

//             Console.WriteLine("\n===== TOTAL BANK BALANCE =====");
//             double totalBalance = accounts.Sum(a => a.Balance);
//             Console.WriteLine("Total Balance: " + totalBalance);

//             Console.WriteLine("\n===== TOP 3 HIGHEST BALANCE ACCOUNTS =====");
//             var top3 = accounts
//                         .OrderByDescending(a => a.Balance)
//                         .Take(3);

//             foreach (var acc in top3)
//             {
//                 Console.WriteLine($"{acc.Name} - {acc.Balance}");
//             }

//             Console.WriteLine("\n===== GROUPED BY ACCOUNT TYPE =====");
//             var grouped = accounts.GroupBy(a => a.GetType().Name);

//             foreach (var group in grouped)
//             {
//                 Console.WriteLine("\nAccount Type: " + group.Key);

//                 foreach (var acc in group)
//                 {
//                     Console.WriteLine($"{acc.Name} - {acc.Balance}");
//                 }
//             }

//             Console.WriteLine("\n===== CUSTOMERS WHOSE NAME STARTS WITH 'R' =====");
//             var startsWithR = accounts.Where(a => a.Name.StartsWith("R"));

//             foreach (var acc in startsWithR)
//             {
//                 Console.WriteLine($"{acc.Name} - {acc.Balance}");
//             }
//         }
//     }
// }
