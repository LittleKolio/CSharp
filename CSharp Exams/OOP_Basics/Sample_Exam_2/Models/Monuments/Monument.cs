public abstract class Monument
{
    public string Name { get; set; }
    public int Bonus { get; set; }
    public Monument(string name, int bonus)
    {
        this.Name = name;
        this.Bonus = bonus;
    }
}
