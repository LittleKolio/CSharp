using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class Date5Days
    {
        static void Main ()
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            DateTime date = new DateTime(1, m, d);
            DateTime newDate = date.AddDays(5);

            Console.WriteLine("{0:d.MM}", newDate);
        }
    }
}
