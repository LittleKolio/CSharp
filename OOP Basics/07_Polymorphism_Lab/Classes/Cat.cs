﻿using System;

public class Cat : Animal
{
    public Cat(string name, string favouriteFood) 
        : base(name, favouriteFood)
    {
    }

    public override string ExplainMyself()
    {
        return $"I am {base.Name} and my fovourite food is " +
            $"{base.FavouriteFood} MEEOW";
    }

    //public override string ExplainMyself()
    //{
    //    return base.ExplainMyself() + Environment.NewLine + "MEEOW";
    //}
}
