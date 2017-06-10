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

            Stack<string> listPalindromes = new Stack<string>();

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
                if (palindrom) { listPalindromes.Push(word); }
            }

            Console.Write("[");
            while (listPalindromes.Count > 0)
            {
                string delimiter = ", ";
                if (listPalindromes.Count == 1)
                {
                    delimiter = string.Empty;
                }
                Console.Write(listPalindromes.Pop() + delimiter);
            }
            Console.WriteLine("]");
        }
    }
}
