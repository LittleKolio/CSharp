using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays_Lab
{
    class Lab_04_Pascal_Triangle
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            long[][] triangle = new long[input][];

            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][triangle[row].Length - 1] = 1;

                for (int col = 1; col < triangle[row].Length - 1; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
            }

            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
