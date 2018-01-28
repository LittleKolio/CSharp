namespace Trash.Lab03_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab02_Maximum_sum_of_2x2_submatrix
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int[] dimensions = SplitInput(input, ", ");

            int[,] matrix = MatrixReadNLines(dimensions[0], dimensions[1]);

            int row = 0;
            int col = 0;
            int sum = 0;

            for (int r = 0; r < dimensions[0] - 1; r++)
            {
                for (int c = 0; c < dimensions[1] - 1; c++)
                {
                    int currentSum = (
                        matrix[r, c] + 
                        matrix[r + 1, c] + 
                        matrix[r, c + 1] + 
                        matrix[r + 1, c + 1]
                        );

                    if (sum < currentSum)
                    {
                        row = r;
                        col = c;
                        sum = currentSum;
                    }
                }
            }

            Console.WriteLine(matrix[row, col] + " " + matrix[row, col + 1]);
            Console.WriteLine(matrix[row + 1, col] + " " + matrix[row + 1, col + 1]);
            Console.WriteLine(sum);
        }

        private static int[] SplitInput(string input, string delimiter)
        {
            return input
                .Split(delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static int[,] MatrixReadNLines(int row, int col)
        {
            int[,] matrix = new int[row, col];

            for (var r = 0; r < row; r++)
            {
                string line = Console.ReadLine();
                int[] arr = SplitInput(line, ", ");

                //if (line.Length != 5)
                //    throw new FormatException();

                for (var c = 0; c < col; c++)
                {
                    matrix[r, c] = arr[c];
                }
            }

            return matrix;
        }
    }
}
