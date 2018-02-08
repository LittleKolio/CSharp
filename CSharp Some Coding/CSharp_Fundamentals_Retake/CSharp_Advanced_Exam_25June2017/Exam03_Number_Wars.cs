namespace Trash.CSharp_Advanced_Exam_25June2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam03_Number_Wars
    {
        public static Queue<string> p1Hand;
        public static Queue<string> p2Hand;
        public static int turns;
        public static bool endWar;

        public static void Main()
        {
            InitializeProperties();

            while (!endWar && turns < 1000000 && p1Hand.Count > 0 && p2Hand.Count > 0)
            {
                turns++;

                List<string> warCards = new List<string>();

                string p1Card = p1Hand.Dequeue();
                string p2Card = p2Hand.Dequeue();

                warCards.Add(p1Card);
                warCards.Add(p2Card);

                int p1Num = int.Parse(p1Card.Substring(0, p1Card.Length - 1));
                int p2Num = int.Parse(p2Card.Substring(0, p2Card.Length - 1));

                CompareBySum(warCards, p1Num.CompareTo(p2Num));
            }

            PrintResultByCount(p1Hand.Count.CompareTo(p2Hand.Count));
        }

        private static void InitializeProperties()
        {
            p1Hand = new Queue<string>(SplitInput(Console.ReadLine(), " "));
            p2Hand = new Queue<string>(SplitInput(Console.ReadLine(), " "));
            turns = 0;
            endWar = false;
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
            if (p1Hand.Count >= 3 && p2Hand.Count >= 3)
            {
                int p1Sum = 0;
                int p2Sum = 0;

                for (int i = 0; i < 3; i++)
                {
                    string p1Card = p1Hand.Dequeue();
                    string p2Card = p2Hand.Dequeue();

                    warCards.Add(p1Card);
                    warCards.Add(p2Card);

                    p1Sum += p1Card.Last() - 'a' + 1;
                    p2Sum += p2Card.Last() - 'a' + 1;
                }

                CompareBySum(warCards, p1Sum.CompareTo(p2Sum));
            }
            else
            {
                endWar = true;
                PrintResultByCount(p1Hand.Count.CompareTo(p2Hand.Count));
            }
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
