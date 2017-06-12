using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Exercises
{
    class Exercises_02_Sets_Of_Elements
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
            }

            for (int i = 0; i < input[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                second.Add(num);
            }

            first.IntersectWith(second);

            Console.WriteLine(string.Join(" ", first));
        }
    }
}
