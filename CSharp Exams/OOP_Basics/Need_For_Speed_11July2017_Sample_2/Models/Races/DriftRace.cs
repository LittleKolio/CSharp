using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override void DetermineWinners(List<Car> cars)
    {
        base.Winners = cars
            .OrderByDescending(c => c.SuspensionPerformance)
            .Take(3)
            .Select(c => string.Format("{0} {1} {2}PP", c.Brand, c.Model, c.SuspensionPerformance))
            .ToList();

        base.isOver = true;
    }
}