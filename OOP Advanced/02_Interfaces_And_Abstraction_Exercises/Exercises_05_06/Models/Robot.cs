using System;

public class Robot : IRobot
{
    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }
    public string Model { get; private set; }
    public string Id { get; private set; }

    public bool CheckId(string digits)
    {
        return this.Id.EndsWith(digits);
    }
}
