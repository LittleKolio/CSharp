using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class IncreasingElements
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
          
            if (n != 0)
            {
                int num1 = int.Parse(Console.ReadLine());

                int count = 1;
                int result = 1;

                for (int i = 1; i < n; i++)
                {
                    int num2 = int.Parse(Console.ReadLine());
                    if (num1 < num2)
                    {
                        count++;
                        if (count > result)
                        {
                            result = count;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                    num1 = num2;
                }

                Console.WriteLine(result);
            }
            else if (n == 0)
            {
                Console.WriteLine(0);
            }
        }
    }
}
