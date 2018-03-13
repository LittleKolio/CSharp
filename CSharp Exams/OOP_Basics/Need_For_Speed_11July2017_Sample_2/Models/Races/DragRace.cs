using System.Collections.Generic;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool, IEnumerable<Car> participiants) 
        : base(length, route, prizePool, participiants)
    {
    }
}