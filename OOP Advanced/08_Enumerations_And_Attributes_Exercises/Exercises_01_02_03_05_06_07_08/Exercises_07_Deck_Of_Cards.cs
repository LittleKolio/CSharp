namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_07_Deck_Of_Cards
    {
        static void Main()
        {
            string[] suits = Enum.GetNames(typeof(CardSuits));
            string[] ranks = Enum.GetNames(typeof(CardRanks));

            foreach (var suit in suits)
            {
                Console.WriteLine($"Ace of {suit}");
                foreach (var rank in ranks)
                {
                    if (rank != "Ace")
                    {
                        Console.WriteLine($"{rank} of {suit}");
                    }
                }
            }
        }
    }
}
