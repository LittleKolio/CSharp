using System;

namespace CSharpAdvanced.Other
{
    class Exercises08RecursiveFibonacci
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
