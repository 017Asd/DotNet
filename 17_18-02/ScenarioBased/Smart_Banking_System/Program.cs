using System;
using System.Collections.Generic;

namespace Q2
{
    public class Program
    {
        public static void Main()
        {
            List<BankAccount> accounts = new List<BankAccount>
            {
                new SavingsAccount(101, "Rahul", 50000),
                new CurrentAccount(102, "Ritika", 30000),
                new LoanAccount(103, "Aman", 100000)
            };

            while (true)
            {
                Console.WriteLine("\n1. Display Accounts");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Calculate Interest");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        foreach (var acc in accounts)
                        {
                            Console.WriteLine($"{acc.AccountNumber} | {acc.Name} | {acc.GetType().Name}");
                        }
                        break;

                    case 2:
                        PerformDeposit(accounts);
                        break;

                    case 3:
                        PerformWithdraw(accounts);
                        break;

                    case 4:
                        CheckBalance(accounts);
                        break;

                    case 5:
                        foreach (var acc in accounts)
                        {
                            Console.WriteLine($"{acc.Name} Interest: {acc.CalculateInterest()}");
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static BankAccount FindAccount(List<BankAccount> accounts, int accNo)
        {
            foreach (var acc in accounts)
            {
                if (acc.AccountNumber == accNo)
                    return acc;
            }
            return null;
        }

        static void PerformDeposit(List<BankAccount> accounts)
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            BankAccount account = FindAccount(accounts, accNo);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            account.Deposit(amount);
            Console.WriteLine("Deposit successful.");
        }

        static void PerformWithdraw(List<BankAccount> accounts)
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            BankAccount account = FindAccount(accounts, accNo);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            account.Withdraw(amount);
            Console.WriteLine("Withdrawal successful.");
        }

        static void CheckBalance(List<BankAccount> accounts)
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());

            BankAccount account = FindAccount(accounts, accNo);

            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance}");
        }
    }
}
