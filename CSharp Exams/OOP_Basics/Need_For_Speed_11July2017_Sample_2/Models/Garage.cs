using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars { get; set; }
}