﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    class Exercises_10_Unicode_Characters
    {
        static void Main()
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            foreach (char symbol in text)
            {
                result.AppendFormat(@"\u{0:x4}", (uint)symbol);
            }

            Console.WriteLine(result);

            //char c = Console.ReadKey().KeyChar;
            //Console.WriteLine(@"\u{0:x4}", (uint)c);
        }
    }
}
