namespace Encapsulation_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Exercises_04_Shopping_Spree
    {
        static List<Person> people;
        static List<Product> products;

        static void Main()
        {
            try
            {
                AddPeople(Console.ReadLine());
                AddProducts(Console.ReadLine());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = SplitInput(input, " ");

                try
                {
                    people
                    .FirstOrDefault(p => p.Name == tokens[0])
                    .BuyingProduct(
                        products .FirstOrDefault(p => p.Name == tokens[1])
                    );

                    Console.WriteLine($"{tokens[0]} bought {tokens[1]}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }


        }

        private static void AddProducts(string inputProducts)
        {
            products = SplitInput(inputProducts, ";")
                .Select(str =>
                {
                    string[] info = SplitInput(str, "=");
                    return new Product(info[0], decimal.Parse(info[1]));
                })
                .ToList();
        }

        private static void AddPeople(string inputPeople)
        {
            people = SplitInput(inputPeople, ";")
                .Select(str =>
                {
                    string[] info = SplitInput(str, "=");
                    return new Person(info[0], decimal.Parse(info[1]));
                })
                .ToList();
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
