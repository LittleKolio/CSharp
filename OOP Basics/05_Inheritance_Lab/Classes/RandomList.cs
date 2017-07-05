using System;
using System.Collections;

class RandomList : ArrayList
{
    private Random rnd;
    public RandomList()
    {
        this.rnd = new Random();
    }

    //public string RandomString()
    //{
    //    int index = rnd.Next(0, data.count);
    //    return null;
    //}
}
