namespace Polymorphism_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_03_Wild_Farm
    {
        static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInput = input
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string[] foodInput = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                switch (animalInput[0])
                {
                    case "Mouse":
                        Animal mouse = new Mouse(
                            animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                        Feed(mouse, foodInput);
                        break;
                    case "Cat":
                        Animal cat = new Cat(
                            animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);
                        Feed(cat, foodInput);
                        break;
                    case "Tiger":
                        Animal tiger = new Tiger(
                            animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                        Feed(tiger, foodInput);
                        break;
                    case "Zebra":
                        Animal zebra = new Zebra(
                            animalInput[1], double.Parse(animalInput[2]), animalInput[3]);
                        Feed(zebra, foodInput);
                        break;
                }
            }
        }

        private static void Feed(Animal animal, string[] foodInput)
        {
            Console.WriteLine(animal.MakeSound());

            try
            {
                switch (foodInput[0])
                {
                    case "Vegetable":
                        animal.Eat(new Vegetable(int.Parse(foodInput[1])));
                        break;
                    case "Meat":
                        animal.Eat(new Meat(int.Parse(foodInput[1])));
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(animal);
        }
    }
}
