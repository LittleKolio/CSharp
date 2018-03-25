namespace Generic_Box
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Exercise04_Generic_Swap_Method_Strings
    {
        public static void Main()
        {
            List<Box<string>> list = new List<Box<string>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }

            int[] swapIndexes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(list, swapIndexes[0], swapIndexes[1]);

            foreach (Box<string> item in list)
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
