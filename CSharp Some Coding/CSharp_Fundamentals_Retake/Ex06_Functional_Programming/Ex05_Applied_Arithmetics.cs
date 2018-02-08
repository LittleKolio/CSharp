namespace Trash.Ex06_Functional_Programming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex05_Applied_Arithmetics
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> add = num => num + 1;
            Func<int, int> multiply = num => num * 2;
            Func<int, int> subtract = num => num - 1;

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                switch (cmd)
                {
                    case "add": Iterate(input, add); break;
                    case "multiply": Iterate(input, multiply); break;
                    case "subtract": Iterate(input, subtract); break;
                    case "print": Console.WriteLine(string.Join(" ", input)); break;
                    default:
                        break;
                }
            }
        }

        private static void Iterate(int[] input, Func<int, int> func)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = func(input[i]);
            }
        }
    }
}
