using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override void DetermineWinners(List<Car> cars)
    {
        base.Winners = cars
            .OrderByDescending(c => c.EnginePerformance)
            .Take(3)
            .Select(c => string.Format("{0} {1} {2}PP", c.Brand, c.Model, c.EnginePerformance))
            .ToList();

        base.isOver = true;
    }
}