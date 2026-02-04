using System;
class BankAccount
{
    static void Main()
    {
        int balance = 10000;

        Console.WriteLine("Enter withdrawal amount:");
        int amount = int.Parse(Console.ReadLine());
        try
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if(amount > balance)
            {
               throw new InvalidOperationException("amount cannot more than balance");
            }
            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
            Console.WriteLine("Remaining Balance: " + balance);
            
            
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine("Error: "+ex.Message); 
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine("Error: "+ex.Message); 
        }
        finally
        {
            Console.WriteLine($"The balance is {balance} and amount is {amount}");
            
        }


        // TODO:
        // 1. Throw exception if amount <= 0
        // 2. Throw exception if amount > balance
        // 3. Deduct amount if valid
        // 4. Use finally block to log transaction
    }
}