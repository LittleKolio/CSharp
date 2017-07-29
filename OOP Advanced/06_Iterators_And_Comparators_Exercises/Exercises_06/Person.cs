public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public int Age { get; private set; }
    public string Name { get; private set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}