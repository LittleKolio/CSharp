using System.Collections.Generic;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
        base.foodList = new List<string> { "Vegetable", "Fruit", "Meat", "Seeds" };
        base.weightModifier = 0.35;
        base.sound = "Cluck";
    }
}