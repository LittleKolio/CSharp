using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    /// <summary>
    /// You will be given N and M - integers, indicating the dimensions of the garden.
    /// The garden is empty at the beginning, every place for a flower to be presented with a zero (0).
    /// You will start receiving two integers - Row and Column, separated by a single space – which represent the position at which to plant a flower.
    /// Until you receive the command "Bloom Bloom Plow".
    /// When a flower blooms it spread to its left, right, up, and down, increasing their value with 1.
    ///  Flowers can bloom multiple times, and each time the flower blooms its value increases.
    ///  If one flower blooms and affects another flower places, it does NOT override their values with 1 again. Instead it blooms them one more time – increasing their value with 1.
    /// </summary>
    /// <output>
    /// Print the whole garden - each row of it on a new line, and each column - separated by a single space.
    /// </output>
    /// <remarks>
    /// The dimensions of the matrix (N and M) will be integers in the range [3, 500].
    /// The integers received as position of planting a flower will always be inside the matrix.
    /// Flowers will always be planted on empty places.
    /// Allowed time/memory: 100ms/16MB.
    /// </remarks>
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
