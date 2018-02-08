namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex04_Find_Evens_Or_Odds
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string cmd = Console.ReadLine().ToLower();

            Func<int, bool> odd = num => num % 2 != 0;
            Func<int, bool> even = num => num % 2 == 0;

            List<int> nums = null;

            if (cmd == "odd")
            {
                nums = Enumerable
                    .Range(input[0], input[1] - input[0] + 1)
                    .Where(odd)
                    .ToList();
            }
            else if (cmd == "even")
            {
                nums = Enumerable
                    .Range(input[0], input[1] - input[0] + 1)
                    .Where(even)
                    .ToList();
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
