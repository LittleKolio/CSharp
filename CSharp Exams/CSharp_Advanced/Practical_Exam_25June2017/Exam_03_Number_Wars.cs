using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Exam_25June2017
{
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
    class Exam_03_Number_Wars
    {
        public static Queue<string> player1;
        public static Queue<string> player2;

        static void Main()
        {
            player1 = new Queue<string>(
                Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                );
            player2 = new Queue<string>(
                Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                );

            int turns = 0;
            bool ravenstvo = false;
            while (
                player1.Count > 0 && 
                player2.Count > 0 && 
                turns < 1000000)
            {
                List<string> hand = new List<string>();
                string player = "";
                
                string card_P1 = player1.Dequeue();
                string card_P2 = player2.Dequeue();

                long card_P1_Num = long.Parse(card_P1.Remove(card_P1.Length - 1));
                long card_P2_Num = long.Parse(card_P2.Remove(card_P2.Length - 1));

                hand.Add(card_P1);
                hand.Add(card_P2);

                if (card_P1_Num == card_P2_Num)
                {
                    ravenstvo = true;

                    long sum_P1 = 0;
                    long sum_P2 = 0;

                    while (player1.Count > 2 && player2.Count > 2)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            string war_P1 = player1.Dequeue();
                            string war_P2 = player2.Dequeue();
                            sum_P1 += (war_P1.Last() - 'a') + 1;
                            sum_P2 += (war_P2.Last() - 'a') + 1;
                            hand.Add(war_P1);
                            hand.Add(war_P2);
                        }

                        if (sum_P2 != sum_P1)
                        {
                            ravenstvo = false;
                            break;
                        }
                    }

                    if (sum_P1 > sum_P2) { player = "p1"; }
                    if (sum_P1 < sum_P2) { player = "p2"; }
                }

                if (card_P1_Num > card_P2_Num) { player = "p1"; }
                if (card_P1_Num < card_P2_Num) { player = "p2"; }

                if (!ravenstvo) { CardsPlayer(hand, player); }
                
                turns++;
            }

            if (ravenstvo && player1.Count < 3 && player2.Count < 3)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (player1.Count > player2.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if(player1.Count < player2.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }

        private static void CardsPlayer(List<string> hand, string player)
        {
            foreach (var card in 
                hand
                .OrderByDescending(c => long.Parse(c.Remove(c.Length - 1)))
                .ThenByDescending(c => c.Last())
                )
            {
                if (player == "p1") { player1.Enqueue(card); }
                if (player == "p2") { player2.Enqueue(card); }
            }
        }
    }
}
