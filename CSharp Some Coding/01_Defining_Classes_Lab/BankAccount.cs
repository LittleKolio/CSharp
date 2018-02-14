using System;

class BankAccount
{
    private int id;
    private decimal balance;
    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public decimal Balance
    {
        get { return this.balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Balance can not be negative!");
            }
            this.balance = value;
        }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.Id}, balance {this.Balance}";
    }
}
