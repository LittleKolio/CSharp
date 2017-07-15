using System.Collections.Generic;

public class Garage
{
    private Dictionary<int, Car> parkedCars;
    public Garage()
    {
        this.parkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars
    {
        get { return this.parkedCars; }
    }

    public void Park(int id, Car car)
    {
        this.parkedCars.Add(id, car);
    }
    public void Unpark(int id)
    {
        this.parkedCars.Remove(id);
    }
    public bool IsParked(int id)
    {
        return this.parkedCars.ContainsKey(id);
    }
    public void Tune(int index, string addOn)
    {
        foreach (Car car in this.ParkedCars.Values)
        {
            car.Tune(index, addOn);
        }
    }
}
