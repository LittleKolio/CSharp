using System.Collections.Generic;

public abstract class Race
{
    public Race(int length, string route, int prizePool, IEnumerable<Car> participiants)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>(participiants);
    }

    public int Length { get; private set; }
    public string Route { get; private set; }
    public int PrizePool { get; private set; }
    public List<Car> Participants { get; private set; }
}