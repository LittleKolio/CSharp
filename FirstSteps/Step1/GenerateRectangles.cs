using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class GenerateRectangles
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int area = int.Parse(Console.ReadLine());

            if (Math.Sqrt(num) < area)
            {
                Console.WriteLine("No");
            }
            else
            {

            }
        }
    }
}
