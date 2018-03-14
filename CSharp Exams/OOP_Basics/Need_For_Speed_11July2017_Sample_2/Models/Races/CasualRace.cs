using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override void DetermineWinners(List<Car> cars)
    {
        base.Winners = cars
            .OrderByDescending(c => c.OverallPerformance)
            .Take(3)
            .Select(c => string.Format("{0} {1} {2}PP", c.Brand, c.Model, c.OverallPerformance))
            .ToList();

        base.isOver = true;
    }
}