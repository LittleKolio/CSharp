public abstract class Bender
{
    public string Name { get; set; }
    public int Power { get; set; }
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public abstract double TotalPower();
}
