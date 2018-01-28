namespace Multidimensional_Arrays_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab_02_Maximum_Sum_Of_2x2_Submatrix
    {
        public static void Main()
        {
            string str = Console.ReadLine();
            int[] input = SplitInput(str, ", ");

            int[][] matrix = new int[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                string line = Console.ReadLine();
                matrix[row] = SplitInput(line, ", ");
            }

            int sum = 0;
            int[] cell = { 0, 0 };

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    int tempSum = matrix[row][col] +
                        matrix[row][col + 1] +
                        matrix[row + 1][col] +
                        matrix[row + 1][col + 1];
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        cell[0] = row;
                        cell[1] = col;
                    }
                }
            }


            Console.WriteLine(
                matrix[cell[0]][cell[1]] + " " + 
                matrix[cell[0]][cell[1] + 1]);

            Console.WriteLine(
                matrix[cell[0] + 1][cell[1]] + " " + 
                matrix[cell[0] + 1][cell[1] + 1]);

            //for (int row = cell[0]; row < cell[0] + 2; row++)
            //{
            //    for (int col = cell[1]; col < cell[1] + 2; col++)
            //    {
            //        Console.Write(matrix[row][col] + " ");
            //    }
            //    Console.WriteLine();
            //}

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
    }
}
