using System.Collections.Generic;

public class Garage
{
    public List<int> parkedCars;
    public Garage()
    {
        this.parkedCars = new List<int>();
    }
    public void AddCar(int id)
    {
        this.parkedCars.Add(id);
    }
}
