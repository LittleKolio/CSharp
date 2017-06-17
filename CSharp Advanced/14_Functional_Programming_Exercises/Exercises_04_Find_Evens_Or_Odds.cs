using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_04_Find_Evens_Or_Odds
    {
        static void Main()
        {
            int[] range = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();

            IEnumerable<int> numbers = Enumerable.Range(range[0], range[1] - range[0] + 1);

            Predicate<int> isEven = num => num % 2 == 0;

            PrintNumbers(numbers, command, isEven);
        }

        private static void PrintNumbers(IEnumerable<int> numbers, string command, Predicate<int> isEven)
        {
            List<int> result = new List<int>();
            foreach (var num in numbers)
            {
                if (isEven(num) && command.ToLower() == "even")
                {
                    result.Add(num);
                }
                else if (!isEven(num) && command.ToLower() == "odd")
                {
                    result.Add(num);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
