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
        if (!this.garage.IsParked(carId))
        {
            this.races[raceId].AddParticipant(carId, this.cars[carId]);
        }
    }

    public string Check(int carId)
    {
        return cars[carId].ToString();
    }

    public string Start(int raceId)
    {
        Race currentRace = this.races[raceId];

        if (currentRace.Participants.Any())
        {
            this.races.Remove(raceId);
            return currentRace.Start();
        }
        else
        {
            return Constants.RACE_NO_PARTICIPANTS;
        }
    }

    public void Park(int carId)
    {
        bool racing = this.races.Values.Any(r => r.IsRacer(carId));
        if (!racing)
        {
            this.garage.Park(carId, this.cars[carId]);
        }
    }

    public void Unpark(int carId)
    {
        if (this.garage.IsParked(carId))
        {
            this.garage.Unpark(carId);
        }
    }

    public void Tune(int index, string addOn)
    {
        this.garage.Tune(index, addOn);
    }
}
