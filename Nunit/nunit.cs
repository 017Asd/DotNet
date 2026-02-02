using NUnit.Framework;
using System;

[TestFixture]   // 1) Test attribute for class
public class UnitTest
{
    //  Test 1: Valid Deposit
    [Test]   // 2) Test attribute for method
    public void Test_Deposit_ValidAmount()
    {
        // Arrange
        Program account = new Program(1000m);

        // Act
        account.Deposit(500m);

        // Assert (only one)
        Assert.That(account.Balance, Is.EqualTo(1500m));
    }

    //  Test 2: Negative Deposit
    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000m);

        var ex = Assert.Throws<Exception>(() => account.Deposit(-200m));

        Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
    }

    //  Test 3: Valid Withdraw
    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000m);

        account.Withdraw(300m);

        Assert.That(account.Balance, Is.EqualTo(700m));
    }

    //  Test 4: Withdraw Insufficient Funds
    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(500m);

        var ex = Assert.Throws<Exception>(() => account.Withdraw(800m));

        Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
    }
}
