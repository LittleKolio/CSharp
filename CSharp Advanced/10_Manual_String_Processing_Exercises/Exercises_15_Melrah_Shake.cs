using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    class Exercises_15_Melrah_Shake
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int len = pattern.Length;

                int first = text.IndexOf(pattern);
                int last = text.LastIndexOf(pattern);

                if (first == -1 || last == -1 || text.Length < (len * 2))
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(text);
                    break;
                }

                text = text.Remove(first, len);
                text = text.Remove(last - len, len);
                Console.WriteLine("Shaked it.");

                if (len < 2)
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(text);
                    break;
                }

                pattern = pattern.Remove(len / 2, 1);
            }
        }
    }
}
