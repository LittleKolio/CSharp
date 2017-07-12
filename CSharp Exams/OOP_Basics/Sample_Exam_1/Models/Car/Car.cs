public abstract class Car
{
    public Car(
        string brand, 
        string model, 
        int yearOfProduction, 
        int horsepower, 
        int acceleration, 
        int suspension, 
        int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int Horsepower { get; set; }
    public int Acceleration { get; set; }
    public int Suspension { get; set; }
    public int Durability { get; set; }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}" + "\r\n" +
            $"{this.Horsepower} HP, 100 m / h in {this.Acceleration} s" + "\r\n" +
            $"{this.Suspension} Suspension force, {this.Durability} Durability" + "\r\n";
    }
}
