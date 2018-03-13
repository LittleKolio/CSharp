public class ShowCar : Car
{
    public ShowCar(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceliration, 
        int suspension, 
        int durability,
        int stars) 
        : base(brand, model, yearOfProduction, horsepower, acceliration, suspension, durability)
    {
        this.Stars = stars;
    }

    public int Stars { get; private set; }
}