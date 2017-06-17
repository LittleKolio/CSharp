using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_01_Take_Two
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.Where(num => 10 <= num && num <= 20)
                .Distinct()
                .Take(2)
                .ToList()
                .ForEach(num => Console.Write(num + " "));
        }
    }
}
