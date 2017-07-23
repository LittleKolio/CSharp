using System;

public class Citizen : ISociety, IBirthdate
{
    public Citizen(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }
    public Citizen(string name, int age, string id, DateTime birthdate)
        : this (name, age, id)
    {
        this.Birthdate = birthdate;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public DateTime Birthdate { get; private set; }

    public bool CheckId(string digits)
    {
        return this.Id.EndsWith(digits);
    }

    public bool CheckBirthday(int year)
    {
        return this.Birthdate.Year == year;
    }
}
