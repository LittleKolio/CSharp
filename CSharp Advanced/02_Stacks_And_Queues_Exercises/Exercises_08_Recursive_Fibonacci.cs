﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_And_Queues_Exercises
{
    class Exercises_08_Recursive_Fibonacci
    {
        private static long[] fibNumbers;

        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            fibNums = new long[input];
            Console.WriteLine(GetFibonacci(input - 1));

        }

        private static long GetFibonacci(int index)
        {
            if (index == 0 || index == 1)
            {
                return 1;
            }

            if (fibNums[index] != default(long))
            {
                return fibNums[index];
            }

            return fibNums[index] = GetFibonacci(index - 1) + GetFibonacci(index - 2);
        }
    }
}
