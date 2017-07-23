using System;

public class Pet : IPet
{
    public Pet(string name, DateTime birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }
    public DateTime Birthdate { get; private set; }
    public string Name { get; private set; }

    public bool CheckBirthday(int year)
    {
        return this.Birthdate.Year == year;
    }
}
