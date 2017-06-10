using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises08MultiplyBigNumber
    {
        private static Stack<char> num1;
        private static int num2;
        private static Stack<char> result;

        static void Main()
        {
            num1 = new Stack<char>(
                Console.ReadLine().TrimStart(new[] { '0' }));
            num2 = int.Parse(Console.ReadLine());
            result = new Stack<char>();

            int num = 0;
            while (true)
            {
                int tempNum1 = 0;

                if (num1.Count > 0) { tempNum1 = num1.Pop() - '0'; }

                int tempNum = num + tempNum1 * num2;
                result.Push("0123456789"[tempNum % 10]);

                num = tempNum / 10;

                if (num1.Count == 0 && num == 0) { break; }
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }
    }
}
