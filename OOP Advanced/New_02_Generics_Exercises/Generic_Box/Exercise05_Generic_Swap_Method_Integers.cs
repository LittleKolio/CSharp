namespace Generic_Box
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exercise05_Generic_Swap_Method_Integers
    {
        public static void Main()
        {
            List<Box<int>> list = new List<Box<int>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());
                list.Add(new Box<int>(num));
            }

            int[] swapIndexes = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(list, swapIndexes[0], swapIndexes[1]);

            foreach (Box<int> item in list)
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
