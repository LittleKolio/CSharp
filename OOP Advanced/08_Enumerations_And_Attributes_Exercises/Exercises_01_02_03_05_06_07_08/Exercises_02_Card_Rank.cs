namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_02_Card_Rank
    {
        static void Main()
        {
            string input = Console.ReadLine();

            if (input == "Card Ranks")
            {
                Array cardRanks = Enum.GetValues(typeof(CardRanks));

                Console.WriteLine($"{input}:");

                foreach (var item in cardRanks)
                {
                    Console.WriteLine(
                        $"Ordinal value: {(int)item}; Name value: {item}");
                }
            }
        }
    }
}
