using System;
using System.Linq;

namespace Sample_Exam_1_June2016
{
    class Exam_03_Target_Multiplier
    {
        public static void Main()
        {
            int[] size = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int row = size[0];
            int col = size[1];

            int[][] matrix = new int[row][];

            FillMatrix(row, col, matrix);

            int[] cell = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int cRow = cell[0];
            int cCol = cell[1];

            matrix[cRow][cCol] *= FrameSum(row, col, matrix, cRow, cCol);

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static void FillMatrix(int row, int col, int[][] matrix)
        {
            for (int r = 0; r < row; r++)
            {
                matrix[r] = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        static int FrameSum(int row, int col, int[][] matrix, int cRow, int cCol)
        {
            int sum = 0;
            for (int r = cRow - 1; r <= cRow + 1; r++)
            {
                for (int c = cCol - 1; c <= cCol + 1; c++)
                {
                    if (r == cRow && c == cCol)
                    {
                        continue;
                    }
                    else
                    {
                        sum += matrix[r][c];
                        matrix[r][c] *= matrix[cRow][cCol];
                    }
                }
            }
            return sum;
        }
    }
}
