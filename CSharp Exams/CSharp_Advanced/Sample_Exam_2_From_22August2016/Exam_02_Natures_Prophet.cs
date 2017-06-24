using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    /// <summary>
    /// 
    /// </summary>
    class Exam_02_Natures_Prophet
    {
        static void Main()
        {
            int[] dimencions = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[dimencions[0]][];
            for (int row = 0; row < dimencions[0]; row++)
            {
                matrix[row] = new int[dimencions[1]];
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow") { break; }

                int[] position = input
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                FormatMatrix(ref matrix, position[0], position[1]);
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FormatMatrix(ref int[][] matrix, int row, int col)
        {
            for (int c = 0; c < matrix[row].Length; c++)
            {
                matrix[row][c] += 1;
            }

            for (int r = 0; r < matrix.Length; r++)
            {
                if (r != row) { matrix[r][col] += 1; }
            }
        }
    }
}
