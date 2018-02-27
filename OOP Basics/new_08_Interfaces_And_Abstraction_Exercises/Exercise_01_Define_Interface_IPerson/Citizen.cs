public class Citizen : IPerson
{
    public int Age { get; set; }
    public string Name { get; set; }

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}
