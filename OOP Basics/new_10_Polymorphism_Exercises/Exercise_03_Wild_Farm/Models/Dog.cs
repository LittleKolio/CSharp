using System;
using System.Collections.Generic;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
        base.foodList = new List<string> { "Meat" };
        base.weightModifier = 0.4;
        base.sound = "Woof!";
    }
}