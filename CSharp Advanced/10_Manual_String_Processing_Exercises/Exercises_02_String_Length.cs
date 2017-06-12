using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    class Exercises_02_String_Length
    {
        static void Main()
        {
            int length = 20;

            string text = Console.ReadLine();

            if (text.Length >= length)
            {
                Console.WriteLine(text.Substring(0, length));
            }
            else
            {
                Console.WriteLine(text.PadRight(20, '*'));
            }
        }
    }
}
