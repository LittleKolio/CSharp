using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_07_Bounded_Numbers
    {
        static void Main()
        {
            double temp;

            int[] bound = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(num => num)
                .ToArray();

            Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(num => bound[0] <= num && num <= bound[1])
                .ToList()
                .ForEach(num => Console.Write(num + " "));
        }
    }
}
