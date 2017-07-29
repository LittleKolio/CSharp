using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private IList<CoffeeType> coffeesSold;
    private int coins;
    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get { return this.coffeesSold; }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffee = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        CoffeePrice price = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);

        if (this.coins >= (int)price)
        {
            this.coffeesSold.Add(coffee);
            this.coins = 0;
        }
    }
    public void InsertCoin(string coin)
    {
        Coin c = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)c;
    }
}