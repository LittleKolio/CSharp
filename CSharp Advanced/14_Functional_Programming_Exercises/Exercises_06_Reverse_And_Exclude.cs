using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_06_Reverse_And_Exclude
    {
        static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divNum = int.Parse(Console.ReadLine());

            Stack<int> result = new Stack<int>();

            Predicate<int> divisible = num => num % divNum == 0;

            foreach (var num in list)
            {
                if (!divisible(num))
                {
                    result.Push(num);
                }
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
