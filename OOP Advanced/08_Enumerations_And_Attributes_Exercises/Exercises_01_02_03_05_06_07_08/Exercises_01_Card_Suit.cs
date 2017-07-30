namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_01_Card_Suit
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (input == "Card Suits")
            {
                Array cardSuits = Enum.GetValues(typeof(CardSuits));

                Console.WriteLine($"{input}:");

                foreach (var item in cardSuits)
                {
                    Console.WriteLine(
                        $"Ordinal value: {(int)item}; Name value: {item}");
                }
            }
        }
    }
}
