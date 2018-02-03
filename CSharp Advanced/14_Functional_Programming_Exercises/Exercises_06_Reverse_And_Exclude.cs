namespace Functional_Programming_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_06_Reverse_And_Exclude
    {
        static void Main()
        {
            int[] list = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divNum = int.Parse(Console.ReadLine());

            /*
            Func<int, bool> func = num => num % divNum != 0;

            int[] result = input
                .Where(func)
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ", result));
            */

            Stack<int> result = new Stack<int>(list);

            Predicate<int> divisible = num => num % divNum != 0;

            while (result.Count > 0)
            {
                if (divisible(result.Peek()))
                {
                    Console.Write(result.Pop() + " ");
                }
                else
                {
                    result.Pop();
                }
            }
            Console.WriteLine();
        }
    }
}
