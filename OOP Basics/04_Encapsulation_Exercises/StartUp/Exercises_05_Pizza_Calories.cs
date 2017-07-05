namespace Encapsulation_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_05_Pizza_Calories
    {
        static void Main()
        {
            string[] pizzaInput = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Pizza pizza = new Pizza(
                    pizzaInput[1], 
                    int.Parse(pizzaInput[2]));

                string[] doughInput = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                pizza.Dough = new Dough(
                    doughInput[1].ToLower(), 
                    doughInput[2].ToLower(), 
                    double.Parse(doughInput[3]));

                for (int i = 0; i < int.Parse(pizzaInput[2]); i++)
                {
                    string[] toppingInput = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                    pizza.AddToppings(new Topping(
                        toppingInput[1].ToLower(),
                        double.Parse(toppingInput[2])
                        ));
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
