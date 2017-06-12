using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Manual_String_Processing_Lab
{
    class Lab_04_Special_Words
    {
        static void Main()
        {
            string pattern = "()[]<>,-!? ";

            string[] words = Console.ReadLine()
                .Split(pattern.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            /*
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            for (int w = 0; w < words.Length; w++)
            {
                if (!wordsCount.ContainsKey(words[w]))
                {
                    wordsCount.Add(words[w], 0);
                }

                int strart = 0;
                while (true)
                {
                    int index = text.IndexOf(words[w], strart);
                    if (index == -1) { break; }

                    if (text[index + words[w].Length] == ' ')
                    {
                        wordsCount[words[w]]++;
                    }

                    strart = index + words[w].Length;
                }
            }

            foreach (var word in wordsCount)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
            */

            for (int w = 0; w < words.Length; w++)
            {
                int count = Regex.Matches(text, "(^|\\W)(" + words[w] + ")(\\W|$)").Count;
                Console.WriteLine($"{words[w]} - {count}");
            }
        }
    }
}
