using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(
        int id, 
        string firstName, 
        string lastName, 
        double salary, 
        string corps,
        IList<IRepair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public IList<IRepair> Repairs { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString() + Environment.NewLine);
        sb.Append("Repairs:");
        if (this.Repairs.Any())
        {
            sb.AppendLine();
            sb.Append("  " + string.Join(Environment.NewLine + "  ", this.Repairs));
        }
        return sb.ToString();
    }
}
