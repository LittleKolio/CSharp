using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Exercises04MaximalSum
    {
        static int[][] matrix;
        static int[] cell;

        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            int sum = 0;
            int a = 3;
            cell = new int[] { 0, 0 };

            for (int row = 0; row <= matrix.Length - a; row++)
            {
                for (int col = 0; col <= matrix[row].Length - a; col++)
                {
                    int temp = SumCells(row, col, a);
                    if (temp > sum)
                    {
                        sum = temp;
                        cell[0] = row;
                        cell[1] = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            Print(cell[0], cell[1], a);
        }

        private static void Print(int r, int c, int a)
        {
            for (int row = r; row < r + a; row++)
            {
                int[] temp = matrix[row].Skip(c).Take(a).ToArray();
                Console.WriteLine(string.Join(" ", temp));
            }
        }

        private static int SumCells(int r, int c, int a)
        {
            int sum = 0;
            for (int row = r; row < r + a; row++)
            {
                sum += matrix[row].Skip(c).Take(a).Sum();
            }
            return sum;
        }
    }
}
