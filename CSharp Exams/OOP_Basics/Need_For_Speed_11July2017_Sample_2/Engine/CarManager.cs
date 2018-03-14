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
        car.State = CarState.waiting;
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
        CarState state = this.participants[carId].State;
        if (state != CarState.waiting)
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
        race.DetermineWinners(this.participants);

        return race.ToString();
    }

    public void Park(int id)
    {
        Car car = this.participants[id];
        if (car.State != CarState.waiting)
        {
            return;
        }
        car.State = CarState.park;
    }

    public void Unpark(int id)
    {
        Car car = this.participants[id];
        if (car.State != CarState.park)
        {
            return;
        }
        car.State = CarState.waiting;
    }
    public void Tune(int tuneIndex, string addOn)
    {
        this.participants.Where(r => r.Value.State == CarState.park)
            .Select(r => r.Value)
            .ToList()
            .ForEach(r => TuneCar(r, tuneIndex, addOn));
    }

    private void TuneCar(Car car, int tuneIndex, string addOn)
    {
        car.Horsepower += tuneIndex;
        car.Suspension += tuneIndex / 2;
        if (car.GetType().Name == "ShowCar")
        {
            ((ShowCar)car).Stars += tuneIndex;
        }
        if (car.GetType().Name == "PerformanceCar")
        {
            ((PerformanceCar)car).AddOns.Add(addOn);
        }
    }
}