using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises04ConvertFromBase_10ToBase_N
    {
        static void Main()
        {
            long[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            long baseN = input[0];
            long num = input[1];

            Stack<char> stack = new Stack<char>();

            while (true)
            {
                stack.Push("0123456789"[(int)(num % baseN)]);

                num /= baseN;
                if (num == 0) { break; }
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
