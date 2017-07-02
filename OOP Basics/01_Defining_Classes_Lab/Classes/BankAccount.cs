﻿using System;

class BankAccount
{
    private int id;
    private double balance;

    public int ID
    {
        get { return id; }
        set { this.id = value; }
    }
    public double Balance
    {
        get { return balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Balance can not be negative!");
            }
            this.balance = value;
        }
    }

    public void Deposit(double amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(double amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account ID{this.id}, balance {this.balance:F2}";
    }
}