using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private Dictionary<int, Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new Dictionary<int, Car>();
    }

    public int Length { get; set; }
    public string Route { get; set; }
    public int PrizePool { get; set; }
    public Dictionary<int, Car> Participants
    {
        get { return this.participants; }
    }
    private int FirstPlace
    {
        get
        {
            return this.PrizePool *
            Constants.RACE_FIRSTPLACE_PRICE /
            Constants.MAXIMUM_PERCENTAGE;
        }
    }
    private int SecondPlace
    {
        get
        {
            return this.PrizePool *
            Constants.RACE_SECONDPLACE_PRICE /
            Constants.MAXIMUM_PERCENTAGE;
        }
    }
    private int ThirdPlace
    {
        get
        {
            return this.PrizePool *
            Constants.RACE_THIRDPLACE_PRICE /
            Constants.MAXIMUM_PERCENTAGE;
        }
    }

    public abstract int Points(Car car);

    public void AddParticipant(int id, Car car)
    {
        this.participants.Add(id, car);
    }

    public bool IsRacer(int carId)
    {
        return this.Participants.ContainsKey(carId);
    }

    public string Start()
    {
        List<Car> winners = this.Participants
            .OrderByDescending(p => this.Points(p.Value))
            .Take(Constants.RACE_MAXIMUM_WINNERS)
            .Select(p => p.Value)
            .ToList();

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length}");
        sb.Append($"1. {winners[0].Brand} {winners[0].Model}" +
            $" {this.Points(winners[0])}PP - ${this.FirstPlace}");
        if (winners.Count > 1)
        {
            sb.AppendLine();
            sb.Append($"2. {winners[1].Brand} {winners[1].Model}" +
                $" {this.Points(winners[1])}PP - ${this.SecondPlace}");
        }
        if (winners.Count > 2)
        {
            sb.AppendLine();
            sb.Append($"3. {winners[2].Brand} {winners[2].Model}" +
                $" {this.Points(winners[2])}PP - ${this.ThirdPlace}");
        }

        return sb.ToString();
    }
}
