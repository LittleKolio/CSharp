using System.Collections.Generic;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool, IEnumerable<Car> participiants) 
        : base(length, route, prizePool, participiants)
    {
    }
}