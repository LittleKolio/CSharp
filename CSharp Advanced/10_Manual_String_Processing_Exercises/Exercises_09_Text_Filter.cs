using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    class Exercises_09_Text_Filter
    {
        static void Main()
        {
            string[] banned = Console.ReadLine()
                .Split(new[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries);

            StringBuilder text = new StringBuilder(Console.ReadLine());

            for (int w = 0; w < banned.Length; w++)
            {
                text.Replace(banned[w], new string('*', banned[w].Length));
            }

            Console.WriteLine(text);
        }
    }
}
