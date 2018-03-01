public class Citizen : IPerson
{
    public int Age { get; private set; }
    public string Name { get; private set; }

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
