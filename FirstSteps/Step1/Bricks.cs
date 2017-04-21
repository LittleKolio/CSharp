using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class Bricks
    {
        static void Main()
        {
            double x = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling(x / m / w));
        }
    }
}
