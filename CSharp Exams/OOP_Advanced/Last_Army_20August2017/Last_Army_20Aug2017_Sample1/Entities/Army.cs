﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Army : IArmy
{
    private List<ISoldier> soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers.AsReadOnly();

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        IEnumerable<ISoldier> soldiersToRegen = this.soldiers
            .Where(s => s.GetType().Name == soldierType);

        foreach (ISoldier soldier in soldiersToRegen)
        {
            soldier.Regenerate();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("Soldiers:" + Environment.NewLine);

        foreach (ISoldier soldier in 
            this.soldiers.OrderByDescending(s => s.OverallSkill))
        {
            sb.AppendLine(soldier.ToString());
        }
        return sb.ToString().TrimEnd();
    }
}