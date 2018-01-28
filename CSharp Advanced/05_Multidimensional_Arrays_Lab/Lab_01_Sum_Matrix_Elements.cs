namespace Multidimensional_Arrays_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab_01_Sum_Matrix_Elements
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int[] dimensions = SplitInput(input, ", ");

            int result = MatrixReadNLines(dimensions[0], dimensions[1]);

            Console.WriteLine(dimensions[0]);
            Console.WriteLine(dimensions[1]);
            Console.WriteLine(result);

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

            #region int[]
            /*
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

            Console.WriteLine(input[0]);
            Console.WriteLine(input[1]);
            Console.WriteLine(sum);
            */
            #endregion

        }

        private static int[] SplitInput(string input, string delimiter)
        {
            return input
                .Split(delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static int MatrixReadNLines(int row, int col)
        {
            //int[,] matrix = new int[row, col];
            int result = 0;

            for (var r = 0; r < row; r++)
            {
                string line = Console.ReadLine();
                int[] arr = SplitInput(line, ", ");

                result += arr.Sum();

                //if (line.Length != 5)
                //    throw new FormatException();

                //for (var c = 0; c < col; c++)
                //{
                //    matrix[r, c] = arr[c];
                //}
            }

            return result;
        }
    }
}
