﻿namespace Generics_Exercises
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

            Swap<string>(list, idexes[0], indexes[1]);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void Swap<U>(List<U> list, int index1, int index2)
            where U : class
        {
            U item1 = list[index1];
            list[index1] = list[index2];
            list[index2] = item1;
        }
    }
}
