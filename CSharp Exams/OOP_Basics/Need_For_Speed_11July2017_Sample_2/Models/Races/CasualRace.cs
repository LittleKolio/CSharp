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

    public override void DetermineWinners(Dictionary<int, Car> racers)
    {
        base.Winners = racers
            .Where(r => 
                {
                    bool isInRace = base.Participants.Contains(r.Key);
                    if (isInRace)
                    {
                        r.Value.State = CarState.waiting;
                    }
                    return isInRace;
                }
            )
            .OrderByDescending(r => r.Value.SuspensionPerformance)
            .Take(3)
            .Select(r => string.Format("{0} {1} {2}PP - ",
                r.Value.Brand,
                r.Value.Model,
                r.Value.OverallPerformance))
            .ToList();

        base.isOver = true;
    }
}