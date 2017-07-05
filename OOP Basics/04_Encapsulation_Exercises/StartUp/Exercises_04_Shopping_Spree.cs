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

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] formatInput = input.Split();

                    Person currentPerson = people
                        .Where(p => p.Name == formatInput[0])
                        .FirstOrDefault();

                    Product currentProduct = products
                        .Where(p => p.Name == formatInput[1])
                        .FirstOrDefault();
                    try
                    {
                        currentPerson.BuyingProduct(currentProduct);

                        Console.WriteLine(
                            $"{formatInput[0]} bought {formatInput[1]}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void AddProducts(string inputProducts)
        {
            products = inputProducts
                .Split(new[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(str =>
                {
                    string[] info = str.Split('=');
                    return new Product(
                        info[0], decimal.Parse(info[1]));
                })
                .ToList();
        }

        private static void AddPeople(string inputPeople)
        {
            people = inputPeople
                .Split(new[] { ';' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(str =>
                {
                    string[] info = str.Split('=');
                    return new Person(
                        info[0], decimal.Parse(info[1]));
                })
                .ToList();
        }
    }
}
