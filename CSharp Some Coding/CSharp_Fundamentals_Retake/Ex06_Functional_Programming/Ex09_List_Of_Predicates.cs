namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex09_List_Of_Predicates
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            Func<int, int, bool> func = (a, b) => a % b != 0;

            for (int i = 1; i <= num; i++)
            {
                bool isDivided = IterateThroughDividers(
                    dividers, func, i);
                if (isDivided)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }

        private static bool IterateThroughDividers(
            int[] div, 
            Func<int, int, bool> func, 
            int num)
        {
            for (int i = 0; i < div.Length; i++)
            {
                if (func(num, div[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
