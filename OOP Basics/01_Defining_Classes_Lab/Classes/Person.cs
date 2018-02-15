using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Person(string name, int age)
        : this (name, age, new List<BankAccount>())
    {
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.Age = age;
        this.Name = name;
        this.accounts = accounts;
    }

    public decimal GetBalance()
    {
        return this.accounts.Sum(acc => acc.Balance);
    }
}
