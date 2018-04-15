using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Army : IArmy
{
    private SoldiersFactory soldiersFactory;
    private List<ISoldier> soldiers;

    public Army(SoldiersFactory soldiersFactory)
    {
        this.soldiersFactory = soldiersFactory;
        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers.AsReadOnly();

    public void AddSoldier(ISoldier soldier)
    {
        string type = data[0];
        string name = data[1];
        int age = int.Parse(data[2]);
        double experience = int.Parse(data[3]);
        double endurance = double.Parse(data[4]);

        ISoldier soldier = this.soldiersFactory.CreateSoldier(
            type, name, age, experience, endurance);

        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        throw new NotImplementedException();
    }
}