using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Exercises
{
    /// <summary>
    /// We are given tow lines of big number (0 - 1050 chars)
    /// </summary>
    /// <output>
    /// Display the sum of these numbers
    /// </output>
    /// <remarks>
    /// Do not use BigInteger or BigDecimal
    /// </remarks>
    class Exercises_07_Sum_Big_Numbers
    {
        private static Stack<char> num1;
        private static Stack<char> num2;
        private static Stack<char> result;

        static void Main()
        {
            num1 = new Stack<char>(
                Console.ReadLine().TrimStart(new[] { '0' }));
            num2 = new Stack<char>(
                Console.ReadLine().TrimStart(new[] { '0' }));
            result = new Stack<char>();

            int one = 0;
            while (true)
            {
                int tempNum1 = 0;
                int tempNum2 = 0;
                if (num1.Count > 0) { tempNum1 = num1.Pop() - '0'; }
                if (num2.Count > 0) { tempNum2 = num2.Pop() - '0'; }

                int tempNum = one + tempNum1 + tempNum2;
                result.Push("0123456789"[tempNum % 10]);

                one = tempNum / 10;

                if (num1.Count == 0 && num2.Count == 0 && one == 0) { break; }
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }
    }
}
