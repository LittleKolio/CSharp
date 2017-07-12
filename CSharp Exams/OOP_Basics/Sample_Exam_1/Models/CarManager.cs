using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(
        int id, 
        string type, 
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceleration, 
        int suspension, 
        int durability)
    {
        switch (type)
        {
            case "Performance":
                cars.Add(id, new PerformanceCar(
                    brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                break;
            case "Show":
                cars.Add(id, new ShowCar(
                    brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
                break;
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                races.Add(id, new CasualRace(length, route, prizePool));
                break;
            case "Drag":
                races.Add(id, new DragRace(length, route, prizePool));
                break;
            case "Drift":
                races.Add(id, new DriftRace(length, route, prizePool));
                break;
        }
    }
    public void Participate(int carId, int raceId)
    {
        if (garage.parkedCars.All(id => id != carId))
        {
            races[raceId].AddParticipant(carId);
        }
    }
    public string Start(int id)
    {
        int prize = races[id].PrizePool;

        var winners = races[id].participants
            .Where(key => cars.ContainsKey(key))
            .Select(key => cars[key])
            .Select(car => new
            {
                points = races[id].Points(car),
                info = $"{car.Brand} {car.Model}"
            })
            .OrderByDescending(car => car.points)
            .ToList();

        StringBuilder sb = new StringBuilder();
        sb.Append(winners.First().info);
        //sb.AppendLine($" {winners.First().points}PP - ${ * 0.5}");
        sb.Append(winners.Skip(1).First().info);
        sb.AppendLine($" {winners.Skip(1).First().points}PP - ${races[id].PrizePool * 0.3}");
        sb.Append(winners.Skip(2).First().info);
        sb.AppendLine($" {winners.Skip(2).First().points}PP - ${races[id].PrizePool * 0.2}");

        return sb.ToString();
    }
    public string Check(int id)
    {
        return cars[id].ToString();
    }
    public void Park(int id) { }
    public void Unpark(int id) { }
    public void Tune(int tuneIndex, string addOn) { }


}
