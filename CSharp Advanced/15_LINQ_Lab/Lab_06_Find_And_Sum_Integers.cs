using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lab
{
    class Lab_06_Find_And_Sum_Integers
    {
        static void Main()
        {
            int temp;
            
            List<string> number = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Where(str => int.TryParse(str, out temp))
                .ToList();


            //if (number == 0)
            //{
            //    Console.WriteLine("No match");
            //}
            //else
            //{
            //    Console.WriteLine($"{number:F2}");
            //}
        }
    }
}
