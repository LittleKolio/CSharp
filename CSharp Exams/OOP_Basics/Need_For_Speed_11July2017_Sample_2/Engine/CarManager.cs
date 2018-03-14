using System;
using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> participants;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.participants = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = default(Car);
        switch (type)
        {
            case "Performance": car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability); break;
            case "Show": car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability); break;
            default: break;
        }
        this.participants.Add(id, car);
    }

    public string Check(int id)
    {
        return this.participants[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = default(Race);
        switch (type)
        {
            case "Casual": race = new CasualRace(length, route, prizePool); break;
            case "Drag": race = new DragRace(length, route, prizePool); break;
            case "Drift": race = new DriftRace(length, route, prizePool); break;
            default: break;
        }
        this.races.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        if (this.garage.ParkedCars.Contains(carId))
        {
            return;
        }
        Race race = this.races[raceId];
        race.Participants.Add(carId);
    }

    public string Start(int id)
    {
        Race race = this.races[id];
        if (race.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }
        race.DetermineWinners(this.Cars(race.Participants));
        this.races.Remove(id);

        return race.ToString();
    }

    public void Park(int id)
    {
        if (this.IsInRace(id))
        {
            return;
        }
        this.garage.ParkedCars.Add(id);
    }

    public void Unpark(int id)
    {
        if (!this.garage.ParkedCars.Contains(id))
        {
            return;
        }
        this.garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneCars(
            this.Cars(this.garage.ParkedCars), tuneIndex, addOn);
    }

    private List<Car> Cars(List<int> carsId)
    {
        return this.participants
            .Where(r => carsId.Contains(r.Key))
            .Select(r => r.Value)
            .ToList();
    }

    private bool IsInRace(int id)
    {
        return this.races.Values
            .Select(r => r.Participants)
            .Any(p => p.Contains(id));
    }
}