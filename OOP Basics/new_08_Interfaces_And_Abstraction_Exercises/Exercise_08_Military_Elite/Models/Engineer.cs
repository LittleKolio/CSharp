using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier
{
    public List<Repair> Repairs { get; set; }

    public Engineer(
        int id, 
        string firstname, 
        string lastname, 
        double salary, 
        string corp) 
        : base(id, firstname, lastname, salary, corp)
    {
        this.Repairs = new List<Repair>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
        .AppendLine("Repairs:");
        foreach (Repair repair in this.Repairs)
        {
            sb.AppendLine("  " + repair.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}