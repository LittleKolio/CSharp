using System;
using System.Collections.Generic;
using System.Text;

public abstract class Race
{
    private double[] prizeModifiers = { 0.5, 0.3, 0.2 };
    public bool isOver = false;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<int>();
    }

    public int Length { get; private set; }
    public string Route { get; private set; }
    public int PrizePool { get; private set; }
    public List<int> Participants { get; set; }
    protected List<string> Winners { get; set; }

    public abstract void DetermineWinners(Dictionary<int, Car> racers);

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        for (int i = 1; i <= this.Winners.Count; i++)
        {
            double prize = this.PrizePool * this.prizeModifiers[i - 1];
            sb.AppendLine($"{i}. " + this.Winners[i - 1] + "$" + prize);
        }

        return sb.ToString().TrimEnd();
    }
}