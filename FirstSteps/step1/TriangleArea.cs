using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class TriangleArea
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double side = Math.Max(x2, x3) - Math.Min(x2, x3);
            double height = Math.Max(y1, y2) - Math.Min(y1, y2);

            Console.WriteLine(side * height / 2);
        }
    }
}
