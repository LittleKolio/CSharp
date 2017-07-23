using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(
        int id, 
        string firstName, 
        string lastName, 
        double salary, 
        string corps,
        IList<IMission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public IList<IMission> Missions { get; private set; }

    public void CompleteMission()
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.AppendLine();
        sb.AppendLine("Missions:");
        sb.Append(string.Join(Environment.NewLine + "  ", this.Missions));
        return sb.ToString();
    }
}
