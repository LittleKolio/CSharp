using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Lab01SumMatrixElements
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(", ".ToArray(), 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            #region int[,]
            /*
            int[,] matrix = new int[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] tempRow = Console.ReadLine()
                    .Split(", ".ToArray(),
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = tempRow[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }
            */
            #endregion

            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                .Split(", ".ToArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            int sum = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                sum += matrix[row].Sum();
            }

            Console.WriteLine($"{input[0]}");
            Console.WriteLine($"{input[1]}");
            Console.WriteLine($"{sum}");

            //print matrix
            //foreach (var row in matrix)
            //{
            //    Console.WriteLine(string.Join(" ", row));
            //}
        }
    }
}
