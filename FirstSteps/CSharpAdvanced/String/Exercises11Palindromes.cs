using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises11Palindromes
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
