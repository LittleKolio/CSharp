using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_08_Custom_Comparator
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, (a, b) =>
            {
                if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                if (a > b)
                {
                    return 1;
                }
                if (a < b)
                {
                    return -1;
                }

                return 0;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
