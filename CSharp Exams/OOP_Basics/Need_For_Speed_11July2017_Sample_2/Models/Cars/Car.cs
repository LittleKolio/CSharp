public abstract class Car
{
    public Car(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceliration, 
        int suspension, 
        int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceliration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int YearOfProduction { get; private set; }
    public virtual int Horsepower { get; protected set; }
    public int Acceleration { get; private set; }
    public virtual int Suspension { get; protected set; }
    public int Durability { get; private set; }
}