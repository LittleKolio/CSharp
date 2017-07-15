public abstract class Monument
{
    public string Name { get; set; }
    public Monument(string name)
    {
        this.Name = name;
    }
    public abstract int Bonus();
}
