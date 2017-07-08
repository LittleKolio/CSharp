using System;

public class Dog : Animal
{
    public Dog(string name, string favouriteFood) 
        : base(name, favouriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return $"I am {base.Name} and my fovourite food is " +
            $"{base.FavouriteFood} DJAAF";
    }

    //public override string ExplainMyself()
    //{
    //    return base.ExplainMyself() + Environment.NewLine + "DJAAF";
    //}
}
