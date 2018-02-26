using System;
using System.Reflection;

public static class FactoryFood
{
    public static Food GetFood(string foodType)
    {
        Type food = Type.GetType(foodType);

        //ConstructorInfo[] constructors = food.GetConstructors();
        //return (Food)constructors[0].Invoke(new object[] { });

        if (food == null)
        {
            return new Other();
        }
        else
        {
            return (Food)Activator.CreateInstance(food);
        }
    }
}