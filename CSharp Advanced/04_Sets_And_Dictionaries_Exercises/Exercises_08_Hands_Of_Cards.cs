using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Exercises
{
    class Exercises_08_Hands_Of_Cards
    {
        static void Main()
        {
            Dictionary<string, HashSet<string>> handsOfCsrds 
                = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string[] inputArr = Regex.Split(
                    Console.ReadLine(), 
                    @":\s|,\s",
                    RegexOptions.IgnorePatternWhitespace);

                if (inputArr[0] == "JOKER") { break; }

                ///Array.Copy()
                //string[] cards = new string[inputArr.Length - 1];
                //Array.Copy(inputArr, 1, cards, 0, inputArr.Length - 1);

                ///ArraySegment<T>
                ArraySegment<string> cards = new ArraySegment<string>(
                    inputArr, 1, inputArr.Length - 1);

                if (!handsOfCsrds.ContainsKey(inputArr[0]))
                {
                    //handsOfCsrds[inputArr[0]] = new HashSet<string>(cards);
                    handsOfCsrds.Add(inputArr[0], new HashSet<string>(cards));
                }
                else
                {
                    handsOfCsrds[inputArr[0]].UnionWith(cards);
                }
            }

            ///Test
            //foreach (var item in handsOfCsrds)
            //{
            //    Console.WriteLine(
            //        $"{item.Key} -> {string.Join(" ", item.Value)}");
            //}

            PrintPayersAndScores(handsOfCsrds);
        }

        public static void PrintPayersAndScores(
            Dictionary<string, HashSet<string>> handsOfCsrds)
        {
            foreach (var item in handsOfCsrds)
            {
                int score = CalculateScore(item.Value);
                Console.WriteLine($"{item.Key}: {score}");
            }
        }

        public static int CalculateScore(HashSet<string> cards)
        {
            int totalScore = 0;

            foreach (var card in cards)
            {
                char type = card.Last();
                string power = card.Substring(0, card.Length - 1);

                int score = 0;
                bool isDigit = int.TryParse(power, out score);

                if (!isDigit)
                {
                    switch (power)
                    {
                        case "J": score = 11; break;
                        case "Q": score = 12; break;
                        case "K": score = 13; break;
                        case "A": score = 14; break;
                    }
                }

                switch (type)
                {
                    case 'S': score *= 4; break;
                    case 'H': score *= 3; break;
                    case 'D': score *= 2; break;
                    case 'C': score *= 1; break;
                }

                totalScore += score;
            }

            return totalScore;
        }
    }
}
