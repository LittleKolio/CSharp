using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_12June2016
{
    class Exam_01_Numbers
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            double averageSum = numbers.Average();
            //Console.WriteLine (averageSum);
            if (numbers.Count > 1)
            {
                List<int> sortNum = numbers
                .Where(x => x > averageSum)
                .OrderByDescending(x => x)
                .Take(5)
                .ToList();
                Console.WriteLine(string.Join(" ", sortNum));
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
