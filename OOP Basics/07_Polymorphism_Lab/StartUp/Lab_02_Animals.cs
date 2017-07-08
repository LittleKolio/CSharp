namespace Polymorphism_Lab.StartUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Lab_02_Animals
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();

            //Cat cat = new Cat("Pesho", "Whiskas");
            //Dog dog = new Dog("Gosho", "Meat");

            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            animals.AddRange(new[] { cat, dog });
            PrintAnimals(animals);
        }

        public static void PrintAnimals(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ExplainMyself());
            }
        }
    }
}
