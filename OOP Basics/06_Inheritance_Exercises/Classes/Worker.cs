using System;

class Worker : Human
{
    private decimal salary;
    private int workingHours;

    public Worker(string firstName, string lastName, decimal salary, int workingHours) 
        : base(firstName, lastName)
    {
        this.WorkingHours = workingHours;
        this.Salary = salary;
    }

    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException(
                    "Expected value mismatch! Argument: weekSalary");
            }
            this.salary = value;
        }
    }

    public int WorkingHours
    {
        get { return this.workingHours; }
        set
        {
            if (value < 1 || 12 < value)
            {
                throw new ArgumentException(
                    "Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workingHours = value;
        }
    }

    public decimal PerHour
    {
        get { return this.Salary / (this.WorkingHours * 5); }
    }

    public override string ToString()
    {
        return base.ToString() + 
            $"Week Salary: {this.Salary:F2}\r\n" +
            $"Hours per day: {this.workingHours:F2}\r\n" +
            $"Salary per hour: {this.PerHour:F2}";
    }
}
