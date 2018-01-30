namespace Trash.Ex04_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex03_2x2_Squares_Matrix
    {
        public static string[][] matrix;
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

            int found = 0;

            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < col - 1; j++)
                {
                    //Console.WriteLine(matrix[i][j] + " " + matrix[i][j + 1]);
                    //Console.WriteLine(matrix[i + 1][j] + " " + matrix[i + 1][j + 1]);

                    bool match = 
                        matrix[i][j] == matrix[i + 1][j] &&
                        matrix[i][j] == matrix[i][j + 1] &&
                        matrix[i][j] == matrix[i + 1][j + 1];
                    if (match)
                    {
                        found++;
                    }
                }
            }

            Console.WriteLine(found);
        }

        private static void MatrixReadNLines(int row, int col)
        {
            matrix = new string[row][];

            for (int r = 0; r < row; r++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[r] = input;
            }
        }

    }
}
