using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class PerfectDiamond
    {
        static void Main ()
        {
            int n = int.Parse(Console.ReadLine());

            int row = n * 2 - 1;

            for (int i = 1; i <= row; i++)
            {
                Console.Write(new string(' ', Math.Abs(n - i)) + "*");
                Console.Write(
                    string.Concat(Enumerable.Repeat("-*", n - 1 - Math.Abs(n - i)))
                    );
                Console.WriteLine();
            }
        }
    }
}
