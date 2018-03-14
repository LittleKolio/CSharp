using System.Collections.Generic;
using System.Linq;

public class Garage
{
    public Garage()
    {
        this.ParkedCars = new List<int>();
    }

    public List<int> ParkedCars { get; set; }

    public void TuneCars(List<Car> cars, int tuneIndex, string addOn)
    {
        foreach (var car in cars)
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
}