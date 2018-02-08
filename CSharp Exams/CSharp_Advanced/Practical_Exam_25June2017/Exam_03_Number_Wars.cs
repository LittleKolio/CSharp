namespace Practical_Exam_25June2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// There are two players. Each of them have cards in their hands.
    /// Cards consist of a number and an English letter something like "11f", "53g", "55g", "3k", "66666p".
    /// Every turn of the game, each of the players puts his first card on the field.
    /// The player with the bigger card (higher number) gets both cards and puts them in the bottom of his deck.
    /// When the cards numbers are equal every player has to put 3 more cards on the field.
    /// Again check for winner, but this time you need to check for the bigger sum of letters at the end of the cards.
    /// a -> 1, b -> 2, c -> 3 etc. The player with the biggest sum of these 3 cards collects all cards from the field and put them in his deck.
    /// If there is a draw, the players put 3 new cards from their decks.
    /// At the end turn and all cards from the field go to the winner hand in descending order: Hand - "111f", "111a", "99p", "77a", "55a", "8p"
    /// The game ends under two conditions - if any of the players loses all his cards, he loses the game.
    /// After 1000000 turns, if both players still have cards, the player with more cards wins the game.
    /// </summary>
    /// <output>
    /// You need to print a single line with the winner or draw: "{Result} after {turns} turns".
    /// </output>
    /// <remarks>
    /// Each player will have N cards, where 1 < N < 1000
    /// Each number will contain an integer with a single letter at the end.
    /// Time limit: 0.3 sec.Memory limit: 16 MB.
    /// </remarks>
    /// 
    class Exam_03_Number_Wars
    {
        public static Queue<string> p1Hand;
        public static Queue<string> p2Hand;
        public static int turns;

        public static void Main()
        {
            InitializeProperties();

            while (p1Hand.Count > 0 && p2Hand.Count > 0 && turns < 1000000)
            {
                List<string> warCards = new List<string>();

                string p1Card = p1Hand.Dequeue();
                string p2Card = p2Hand.Dequeue();

                warCards.Add(p1Card);
                warCards.Add(p2Card);

                int p1Num = int.Parse(p1Card.Substring(0, p1Card.Length - 1));
                int p2Num = int.Parse(p2Card.Substring(0, p2Card.Length - 1));

                CompareBySum(warCards, p1Num.CompareTo(p2Num));

                turns++;
            }

            PrintResultByCount(p1Hand.Count.CompareTo(p2Hand.Count));
        }

        private static void InitializeProperties()
        {
            p1Hand = new Queue<string>(SplitInput(Console.ReadLine(), " "));
            p2Hand = new Queue<string>(SplitInput(Console.ReadLine(), " "));
            turns = 0;
        }

        private static void CompareBySum(List<string> warCards, int result)
        {
            if (result > 0) { AddToWinnerHand(p1Hand, warCards); }
            else if (result < 0) { AddToWinnerHand(p2Hand, warCards); }
            else { War(warCards); }
        }

        private static void PrintResultByCount(int result)
        {
            if (result > 0) { Console.Write("First player wins "); }
            else if (result < 0) { Console.Write("Second player wins "); }
            else { Console.Write("Draw "); }
            Console.WriteLine($"after {turns} turns");
        }

        private static void War(List<string> warCards)
        {
            int p1Sum = 0;
            int p2Sum = 0;

            for (int i = 0; i < 3; i++)
            {
                string p1Card = string.Empty;
                string p2Card = string.Empty;
                try
                {
                    p1Card = p1Hand.Dequeue();
                    p2Card = p2Hand.Dequeue();
                }
                catch
                {
                    PrintResultByCount(p1Hand.Count.CompareTo(p2Hand.Count));
                    return;
                }

                warCards.Add(p1Card);
                warCards.Add(p2Card);

                p1Sum += p1Card.Last() - 'a' + 1;
                p2Sum += p2Card.Last() - 'a' + 1;
            }

            CompareBySum(warCards, p1Sum.CompareTo(p2Sum));
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }

        private static void AddToWinnerHand(Queue<string> hand, List<string> cards)
        {
            cards
                .OrderByDescending(card => int.Parse(card.Substring(0, card.Length - 1)))
                .ThenByDescending(card => card.Last())
                .ToList()
                .ForEach(card => hand.Enqueue(card));
        }
    }
}
