using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class Points
    {
        static void Main ()
        {
            int f = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            string state = "out";
            int dist = Math.Min(Math.Abs(f - p), Math.Abs(s - p));

            if (Math.Min(f, s) <= p && Math.Max(f, s) >= p)
                state = "in";

            Console.WriteLine(state);
            Console.WriteLine(dist);
        }
    }
}
