﻿namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PrimeNumber
    {
        static void Main()
        {
            Console.Write("Enter a positive number: ");
            int num = int.Parse(Console.ReadLine());

            int div = 2;
            int maxDiv = (int)Math.Sqrt(num);
            bool isPrime = true;

            while (isPrime && (div <= maxDiv))
            {
                if (num % div == 0)
                {
                    isPrime = false;
                }
                div++;
            }

            Console.WriteLine("Is prome: " + isPrime);
        }
    }


    public static class PrimeTool
    {
        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
         
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }
    }
}
