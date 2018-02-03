namespace Functional_Programming_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_03_Custom_Min_Function
    {
        static void Main()
        {
            Func<int, int, int> minNum = (a, b) => a > b ? b : a;

            int[] numbers = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(CustomSort(numbers, minNum));
        }

        private static int CustomSort(int[] numbers, Func<int, int, int> minNum)
        {
            int temp = int.MaxValue;
            foreach (var num in numbers)
            {
                temp = minNum(num, temp);
            }
            return temp;
        }
    }
}
