namespace Trash.Lab03_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab01_Sum_Matrix_Elements
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int[] dimensions = SplitInput(input, ", ");

            int result = MatrixReadNLines(dimensions[0], dimensions[1]);

            Console.WriteLine(dimensions[0]);
            Console.WriteLine(dimensions[1]);
            Console.WriteLine(result);
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
