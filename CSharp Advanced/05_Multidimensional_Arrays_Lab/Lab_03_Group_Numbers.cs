using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays_Lab
{
    class Lab_03_Group_Numbers
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(", ".ToArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[3][];

            matrix[0] = input.Where(e => Math.Abs(e) % 3 == 0).ToArray();
            matrix[1] = input.Where(e => Math.Abs(e) % 3 == 1).ToArray();
            matrix[2] = input.Where(e => Math.Abs(e) % 3 == 2).ToArray();

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
