namespace Trash.Ex04_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex02_Diagonal_Difference
    {
        public static int[][] matrix;
        public static void Main()
        {
            int dim = int.Parse(Console.ReadLine());

            MatrixReadNLines(dim, " ");

            int sum1 = 0;
            int sum2 = 0;

            for (int row = 0, col = 0; 
                row < dim && col < dim; 
                row++, col++)
            {
                sum1 += matrix[row][col];
            }

            for (int row = 0, col = dim - 1;
                row < dim && col >= 0;
                row++, col--)
            {
                sum2 += matrix[row][col];
            }

            Console.WriteLine(Math.Abs(sum1 - sum2));
        }

        private static void MatrixReadNLines(int dim, string delimiter)
        {
            matrix = new int[dim][];

            for (var row = 0; row < dim; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(delimiter.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
        }
    }
}
