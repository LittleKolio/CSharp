using System;

public class Robot : ISociety
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }
    public string Model { get; set; }
    public string Id { get; private set; }

    public bool CheckId(string digits)
    {
        return this.Id.EndsWith(digits);
    }
}
