using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class SumsStep3
    {
        static void Main ()
        {
            int n = int.Parse(Console.ReadLine());

            const int step = 3;

            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;

            for (int i = 1; i <= n; i++)
            {
                switch (i % step)
                {
                    case 0: sum3 += int.Parse(Console.ReadLine()); break;
                    case 1: sum1 += int.Parse(Console.ReadLine()); break;
                    case 2: sum2 += int.Parse(Console.ReadLine()); break;
                    default: break;
                }
            }

            Console.WriteLine("sum1 = " + sum1);
            Console.WriteLine("sum2 = " + sum2);
            Console.WriteLine("sum3 = " + sum3);
        }
    }
}
