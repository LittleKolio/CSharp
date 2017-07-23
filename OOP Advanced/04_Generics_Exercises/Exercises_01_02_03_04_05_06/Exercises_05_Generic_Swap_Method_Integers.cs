namespace Generics_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_05_Generic_Swap_Method_Integers
    {
        static void Main()
        {
            IList<Box<int>> list = new List<Box<int>>();

            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                list.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            int[] idexes = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SwapElements<int>(list, idexes);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void SwapElements<T>(IList<Box<T>> list, int[] idexes)
        {
            Box<T> element = list[idexes[0]];
            list[idexes[0]] = list[idexes[1]];
            list[idexes[1]] = element;
        }
    }
}
