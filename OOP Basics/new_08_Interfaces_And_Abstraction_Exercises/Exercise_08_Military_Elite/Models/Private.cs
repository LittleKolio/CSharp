public class Private : Soldier, ISalary
{
    public double Salary { get; set; }

    public Private(
        int id, 
        string firstname, 
        string lastname, 
        double salary) 
        : base(id, firstname, lastname, salary)
    {
        this.Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {this.Salary:F2}";
    }
}