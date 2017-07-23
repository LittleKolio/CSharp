using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(
        int id, 
        string firstName, 
        string lastName, 
        double salary,
        IList<ISoldier> soldiers) 
        : base(id, firstName, lastName, salary)
    {
        this.Soldiers = soldiers;
    }

    public IList<ISoldier> Soldiers { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString() + Environment.NewLine);
        sb.Append("Privates:");
        if (this.Soldiers.Any())
        {
            sb.AppendLine();
            sb.Append("  " + string.Join(Environment.NewLine + "  ", this.Soldiers));
        }
        return sb.ToString();
    }
}
