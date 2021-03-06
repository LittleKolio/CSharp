﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regular_Expressions_Exercises
{
    class Exercises_06_Sentence_Extractor
    {
        private const string format = @"[\w\s]+\b{0}\b[\w\s]+(\.|\?|!)";

        static void Main()
        {
            string pattern = string.Format(
                format, 
                Console.ReadLine().Trim());
            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
