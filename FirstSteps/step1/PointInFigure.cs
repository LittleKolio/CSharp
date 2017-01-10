using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class PointInFigure
    {
        static void Main ()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool rectangle1 = (2 <= x && 12 >= x) && (-3 <= y && 1 >= y);
            bool rectangle2 = (4 <= x && 10 >= x) && (-5 <= y && 3 >= y);

            string state = "out";

            if (rectangle1 || rectangle2) { state = "in"; }

            Console.WriteLine(state);
        }
    }
}
