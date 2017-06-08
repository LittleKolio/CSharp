using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Exercises03FormattingNumbers
    {
        static void Main()
        {
            double[] num = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            string format = "{0,10:X}|{0}";
            string textLine = string.Format(format, (int)num[0], Convert.ToString((int)num[0], 8));

            Console.WriteLine(textLine);
        }
    }
}
