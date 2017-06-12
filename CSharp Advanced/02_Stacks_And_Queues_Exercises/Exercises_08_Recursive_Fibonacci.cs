using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_And_Queues_Exercises
{
    class Exercises_08_Recursive_Fibonacci
    {
        private static long[] fibNumbers;

        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            fibNumbers = new long[input];
            long result = GetFib(input);
            Console.WriteLine(result);

        }

        public static long GetFib(int n)
        {

            if (n <= 2)
            {
                return 1;
            }

            if (fibNumbers[n - 1] != 0)
            {
                return fibNumbers[n - 1];
            }

            return fibNumbers[n - 1] = GetFib(n - 1) + GetFib(n - 2);
        }
    }
}
