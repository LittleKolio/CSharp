using System.Collections.Generic;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool, IEnumerable<Car> participiants) 
        : base(length, route, prizePool, participiants)
    {
    }
}