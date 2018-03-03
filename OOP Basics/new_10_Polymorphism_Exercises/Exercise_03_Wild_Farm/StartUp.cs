using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        Animal animal = null;
        int count = 1;
        string input;
        while (!(input = Console.ReadLine()).Equals("End"))
        {
            string[] tokens = SplitInput(input, " ");

            if (count % 2 == 0 && animal != null)
            {
                string food = tokens[0];
                int quantity = int.Parse(tokens[1]);
                try
                {
                    animal.EatFood(food, quantity);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                animal = AnimalFactory(tokens);
                animals.Add(animal);
                Console.WriteLine(animal.Sound);
            }

            count++;
        }

        foreach (Animal an in animals)
        {
            Console.WriteLine(an);
        }
    }

    private static Animal AnimalFactory(string[] tokens)
    {
        Type animalType = Type.GetType(tokens[0]);
        tokens = tokens.Skip(1).ToArray();

        ParameterInfo[] animalParameters = animalType
            .GetConstructors()
            .FirstOrDefault()
            .GetParameters();

        object[] currentParameters = new object[animalParameters.Length];

        for (int i = 0; i < animalParameters.Length; i++)
        {
            Type parameterType = animalParameters[i].ParameterType;
            currentParameters[i] = Convert.ChangeType(tokens[i], parameterType);
        }

        Animal animal = (Animal)Activator.CreateInstance(animalType, currentParameters);

        return animal;
    }


    private static string[] SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries);
    }
}