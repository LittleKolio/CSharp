using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    /// <summary>
    /// Extracts from a given text all palindromes.
    /// Use spaces, commas, dots, question marks and exclamation marks as word delimiters.
    /// </summary>
    /// <output>
    /// Print palindromes on the console on a single line, separated by comma and space.
    /// Only unique palindromes, sorted lexicographically (small letters are before big ones).
    /// </output>
    class Exercises_11_Palindromes
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(" ,.?!".ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);

            List<string> listPalindromes = new List<string>();

            foreach (string word in input)
            {
                int l = word.Length;
                bool palindrom = true;
                for (int i = 0; i < l / 2; i++)
                {
                    if (!(word[i] == word[l - (i + 1)]))
                    {
                        palindrom = false;
                        break;
                    }
                }
                if (palindrom) { listPalindromes.Add(word); }
            }

            Console.WriteLine("[" + string.Join(", ", listPalindromes.OrderBy(w => w)) + "]");
        }
    }
}
