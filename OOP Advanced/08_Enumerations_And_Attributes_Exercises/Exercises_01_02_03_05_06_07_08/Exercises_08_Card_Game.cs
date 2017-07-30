namespace Enumerations_And_Attributes_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercises_08_Card_Game
    {
        private static Card biggest;
        private static string winner;

        static void Main()
        {
            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();

            List<Card> deck = Deck();

            List<Card> firstHand = new List<Card>();
            List<Card> secondHand = new List<Card>();

            while (firstHand.Count < 5 || secondHand.Count < 5)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { "of" },
                        StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Card card = new Card(tokens[1], tokens[0]);
                    if (deck.Contains(card))
                    {
                        deck.Remove(card);
                        if (firstHand.Count < 5)
                        {
                            firstHand.Add(card);
                            Winner(card, firstPlayer);
                        }
                        else
                        {
                            secondHand.Add(card);
                            Winner(card, secondPlayer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            Console.WriteLine($"{winner} wins with {biggest.Name}.");
        }

        public static List<Card> Deck()
        {
            List<Card> deck = new List<Card>();
            foreach (var suit in Enum.GetNames(typeof(CardSuits)))
            {
                foreach (var rank in Enum.GetNames(typeof(CardRanks)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            return deck;
        }

        public static void Winner(Card card, string player)
        {
            if (biggest == null)
            {
                biggest = card;
                winner = player;
            }
            if (biggest.CompareTo(card) < 0)
            {
                biggest = card;
                winner = player;
            }
        }
    }
}
