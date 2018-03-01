using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Soldier, ISalary
{
    private List<string> availableCorps = new List<string>{ "Airforces", "Marines" };

    private string corp;
    public string Corp
    {
        get { return this.corp; }
        set
        {
            if (!availableCorps.Contains(value))
            {
                throw new ArgumentException();
            }
            this.corp = value;
        }
    }

    public double Salary { get; set; }

    public SpecialisedSoldier(
        int id, 
        string firstname, 
        string lastname, 
        double salary, 
        string corp) 
        : base(id, firstname, lastname, salary)
    {
        this.Salary = salary;
        this.Corp = corp;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString() + $" Salary: {this.Salary:F2}")
        .AppendLine($"Corps: {this.Corp}");

        return sb.ToString().TrimEnd();
    }
}