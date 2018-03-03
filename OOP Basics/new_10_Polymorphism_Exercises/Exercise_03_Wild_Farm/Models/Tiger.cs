using System.Collections.Generic;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
        base.foodList = new List<string> { "Meat" };
        base.weightModifier = 1;
        base.sound = "ROAR!!!";
    }
}