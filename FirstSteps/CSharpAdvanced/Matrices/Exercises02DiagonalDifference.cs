using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Exercises02DiagonalDifference
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            int[][] matrix = new int[num][];

            for (int row = 0; row < num; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new[] { ' ' }, 
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int sum1 = 0;
            for (int row = 0, col = 0; 
                row < num || col < num; 
                row++, col++)
            {
                sum1 += matrix[row][col];
            }

            int sum2 = 0;
            for (int row = num - 1, col = 0; 
                row >= 0 || col < num; 
                row--, col++)
            {
                sum2 += matrix[row][col];
            }

            Console.WriteLine(Math.Abs(sum1 - sum2)) ;
        }
    }
}
