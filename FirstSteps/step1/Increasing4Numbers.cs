using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class Increasing4Numbers
    {
        static void Main()
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            if (num2 - num1 < 3)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = num1; i <= num2 - 3; i++)
                {
                    for (int j = i + 1; j <= num2 - 2; j++)
                    {
                        for (int k = j + 1; k <= num2 - 1; k++)
                        {
                            for (int l = k + 1; l <= num2; l++)
                            {
                                Console.WriteLine("{0} {1} {2} {3}", i, j, k, l);
                            }
                        }
                    }
                }
            }
            
        }
    }
}
