﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    class Exercises_05_Convert_From_BaseN_To_Base10
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);

            int nBase = int.Parse(input[0]);
            string number = input[1];

            long power = 1;
            long result = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                result += power * (number[i] - '0');
                power *= nBase;
            }

            Console.WriteLine(result);
        }
    }
}
