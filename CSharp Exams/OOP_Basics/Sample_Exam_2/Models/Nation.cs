using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    public List<Bender> warriors;
    public List<Monument> monuments;
    public Nation()
    {
        this.warriors = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender ben)
    {
        this.warriors.Add(ben);
    }
    public void AddMonument(Monument mon)
    {
        this.monuments.Add(mon);
    }
    public double TotalPower()
    {
        double power = this.warriors.Sum(bender => bender.TotalPower());
        double bonus = this.monuments.Sum(mon => mon.Bonus());
        return power * (bonus / 100 + 1);
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Benders:");
        if (this.warriors.Any())
        {
            sb.AppendLine()
                .AppendLine(string.Join(Environment.NewLine,
                    this.warriors.Select(w => $"###{w}")));
        }
        else { sb.AppendLine(" None"); }

        sb.Append("Monuments:");
        if (this.monuments.Any())
        {
            sb.AppendLine()
                .AppendLine(string.Join(Environment.NewLine,
                    this.monuments.Select(m => $"###{m}")));
        }
        else { sb.AppendLine(" None"); }
        return sb.ToString();
    }
    public void DeclareDefeat()
    {
        this.warriors.Clear();
        this.monuments.Clear();
    }
}
