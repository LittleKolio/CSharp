using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Soldier, ISalary
{
    public List<Soldier> Privates { get; set; }
    public double Salary { get; set; }

    public LeutenantGeneral(int id, string firstname, string lastname, double salary) 
        : base(id, firstname, lastname, salary)
    {
        this.Salary = salary;
        this.Privates = new List<Soldier>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString() + $" Salary: {this.Salary:F2}")
        .AppendLine("Privates:");
        foreach (Private priv in this.Privates)
        {
            sb.AppendLine("  " + priv.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}