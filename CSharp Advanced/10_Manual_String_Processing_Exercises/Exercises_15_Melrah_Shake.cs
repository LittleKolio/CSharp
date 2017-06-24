using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    /// <summary>
    /// You are given a string of random characters and a pattern of random characters.
    /// You need to remove all of the border occurrences of that pattern.
    /// Remove from the pattern the character which corresponds to the index equal to the pattern's length / 2.
    /// Then you continue to remove from the border occurrences of the new pattern until the pattern becomes empty or there is nothing to remove in the remaining string.
    /// </summary>
    /// <output>
    /// You must print "Shaked it." for every time you successfully do removal.
    /// If the removal fails, you print “No shake.”, and on the next line you print what has remained of the main string.
    /// </output>
    /// <remarks>
    /// The two strings may contain ANY ASCII character.
    /// Allowed time/memory: 250ms/16MB.
    /// </remarks>
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
