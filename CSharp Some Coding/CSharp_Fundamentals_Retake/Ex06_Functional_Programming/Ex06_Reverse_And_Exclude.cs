namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex06_Reverse_And_Exclude
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int num = int.Parse(Console.ReadLine());

            Func<int, bool> func = n => n % num != 0;

            int[] result = input
                .Where(func)
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
