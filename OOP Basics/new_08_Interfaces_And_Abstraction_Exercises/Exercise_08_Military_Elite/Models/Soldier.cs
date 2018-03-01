using System;

public abstract class Soldier : ISoldier
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Soldier(int id, string firstname, string lastname, double salary)
    {
        this.Id = id;
        this.FirstName = firstname;
        this.LastName = lastname;
    }

    public override string ToString()
    {
        return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}