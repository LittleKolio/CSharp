using System.Collections.Generic;

public class CarFactory
{
    public Car GetCar(List<string> args, Tyre tyre)
    {
        int horsepower;
        bool isHorsepower = int.TryParse(args[0], out horsepower);
        double fuelAmount;
        bool isFuelAmount = double.TryParse(args[1], out fuelAmount);

        if (!isHorsepower || !isFuelAmount)
        {
            return null;
        }

        return new Car(horsepower, fuelAmount, tyre);
    }
}