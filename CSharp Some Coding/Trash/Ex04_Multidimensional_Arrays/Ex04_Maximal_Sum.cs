namespace Trash.Ex04_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex04_Maximal_Sum
    {
        public static int[][] matrix;
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int row = nums[0];
            int col = nums[1];

            MatrixReadNLines(row, col);

            int sum = 0;
            int[] cell = { 0, 0 };

            for (int r = 0; r < row - 2; r++)
            {
                for (int c = 0; c < col - 2; c++)
                {
                    int currentSum = Sum(r, c);
                    if (sum < currentSum)
                    {
                        sum = currentSum;
                        cell[0] = r;
                        cell[1] = c;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");
            Print(cell[0], cell[1]);
        }

        private static int Sum(int row, int col)
        {
            int sum = 0;

            for (int r = row; r < row + 3; r++)
            {
                for (int c = col; c < col + 3; c++)
                {
                    sum += matrix[r][c];
                }
            }

            return sum;
        }

        private static void Print(int row, int col)
        {
            for (int r = row; r < row + 3; r++)
            {
                for (int c = col; c < col + 3; c++)
                {
                    Console.Write(matrix[r][c] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void MatrixReadNLines(int row, int col)
        {
            matrix = new int[row][];

            for (int r = 0; r < row; r++)
            {
                int[] input = Console.ReadLine()
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[r] = input;
            }
        }
    }
}
