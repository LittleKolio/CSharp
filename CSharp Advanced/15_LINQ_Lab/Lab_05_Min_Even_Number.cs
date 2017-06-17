using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_05_Min_Even_Number
    {
        static void Main()
        {
            double number = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Where(num => num % 2 == 0)
                .OrderBy(num => num)
                .FirstOrDefault();

            if (number == 0)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
