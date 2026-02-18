using System.Data;
using System.Security;

namespace Q2
{
    public abstract class BankAccount
    {
        public int AccountNumber{get;set;}
        public string Name{get;set;}
        public double Balance{get;set;}

        public BankAccount()
        {
            
        }
        public  BankAccount(int accountnumber,string name,double balance)
        {
            this.AccountNumber=accountnumber;
            this.Name=name;
            this.Balance=balance;
        }
        public  void Deposit(double amount)
        {
            Rules.ValidateDeposit(amount);
            Balance+=amount;
        }
        public  void Withdraw(double amount)
        {
            Rules.ValidateWithdrawal(amount);
            Rules.ValidateBalance(Balance,amount);
            Balance-=amount;
        }
        public abstract double CalculateInterest();

    }
}