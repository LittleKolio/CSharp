using System;
using System.Collections.Generic;
using System.Text;

public class NationBuilder
{
    private Dictionary<string, Nation> nations;
    public NationBuilder()
    {
        this.nations = new Dictionary<string, Nation>
        {
            { "Air", new Nation() },
            { "Water", new Nation() },
            { "Fire", new Nation() },
            { "Earth", new Nation() }
        };
    }
    public void AssignBender(List<string> benStats)
    {
        string type = benStats[0];
        string name = benStats[1];
        int power = int.Parse(benStats[2]);
        double secParam = double.Parse(benStats[3]);

        switch (type)
        {
            case "Air":
                this.nations[type].AddBender(
                    new AirBender(name, power, secParam));
                break;
            case "Water":
                this.nations[type].AddBender(
                    new WaterBender(name, power, secParam));
                break;
            case "Fire":
                this.nations[type].AddBender(
                    new FireBender(name, power, secParam));
                break;
            case "Earth":
                this.nations[type].AddBender(
                    new EarthBender(name, power, secParam));
                break;
        }
    }
    public void AssignMonument(List<string> monStats)
    {
        string type = monStats[0];
        string name = monStats[1];
        int affinity = int.Parse(monStats[2]);

        switch (type)
        {
            case "Air":
                this.nations[type].AddMonument(
                    new AirMonument(name, affinity));
                break;
            case "Water":
                this.nations[type].AddMonument(
                    new WaterMonument(name, affinity));
                break;
            case "Fire":
                this.nations[type].AddMonument(
                    new FireMonument(name, affinity));
                break;
            case "Earth":
                this.nations[type].AddMonument(
                    new EarthMonument(name, affinity));
                break;
        }
    }
    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation")
            .Append(this.nations[nationsType]);

        return sb.ToString();
    }
    public void IssueWar(string nationsType)
    {
        //TODO: Add some logic here … 
    }
    public string GetWarsRecord()
    {
        //TODO: Add some logic here … 
    }

}
