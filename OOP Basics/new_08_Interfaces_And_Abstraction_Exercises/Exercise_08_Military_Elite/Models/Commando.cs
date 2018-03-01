using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier
{
    public List<Mission> Missions { get; set; }

    public Commando(
        int id,
        string firstname,
        string lastname,
        double salary,
        string corp)
        : base(id, firstname, lastname, salary, corp)
    {
        this.Missions = new List<Mission>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString())
        .AppendLine("Missions:");
        foreach (Mission mission in this.Missions)
        {
            sb.AppendLine("  " + mission.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}