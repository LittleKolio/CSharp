namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Exercises_05_Card_CompareTo
    {
        static void Main()
        {
            Card card1 = CreateCard();
            Card card2 = CreateCard();

            if (card1.CompareTo(card2) > 0)
            {
                Console.WriteLine(card1);
            }
            else
            {
                Console.WriteLine(card2);
            }
        }

        private static Card CreateCard()
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            return new Card(suit, rank);
        }
    }
}
