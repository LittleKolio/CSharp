using System.Collections.Generic;

public abstract class Race
{
    public List<int> participants;
    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new List<int>();
    }
    public int Length { get; set; }
    public string Route { get; set; }
    public int PrizePool { get; set; }

    public abstract int Points(Car car);

    public void AddParticipant(int id)
    {
        this.participants.Add(id);
    }
}
