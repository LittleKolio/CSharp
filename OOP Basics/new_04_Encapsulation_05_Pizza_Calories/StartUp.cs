using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    public static void Main(string[] args)
    {
        string pizzaName = SplitInput(Console.ReadLine(), " ").Skip(1).First();
        Pizza pizza = new Pizza(pizzaName);

        string[] doughProp = SplitInput(Console.ReadLine(), " ").Skip(1).ToArray();
        try
        {
            Dough dough = new Dough(doughProp[0], doughProp[1], double.Parse(doughProp[2]));
            pizza.SetDough(dough);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        string input;
        while (!(input = Console.ReadLine()).Equals("END"))
        {
            string[] toppingProp = SplitInput(input, " ").Skip(1).ToArray();
            try
            {
                Topping topping = new Topping(toppingProp[0], double.Parse(toppingProp[1]));
                pizza.AddTopplings(topping);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        Console.WriteLine(pizza);
    }

    private static string[] SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries);
    }
}
