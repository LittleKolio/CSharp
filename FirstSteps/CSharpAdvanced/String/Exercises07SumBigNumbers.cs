using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises07SumBigNumbers
    {
        static void Main()
        {
            Stack<char> num1 = new Stack<char>(Console.ReadLine());
            Stack<char> num2 = new Stack<char>(Console.ReadLine());

            while (num1.Count > 0)
            {
                Console.Write(num1.Pop());
            }
        }
    }
}
