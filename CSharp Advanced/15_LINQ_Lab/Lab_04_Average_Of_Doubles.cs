using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_04_Average_Of_Doubles
    {
        static void Main()
        {
            double num = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .Average();

            Console.WriteLine($"{num:F2}");
        }
    }
}
