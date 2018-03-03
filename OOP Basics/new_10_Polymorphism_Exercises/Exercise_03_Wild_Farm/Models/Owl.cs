using System.Collections.Generic;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
        base.foodList = new List<string> { "Meat" };
        base.weightModifier = 0.25;
        base.sound = "Hoot Hoot";
    }
}