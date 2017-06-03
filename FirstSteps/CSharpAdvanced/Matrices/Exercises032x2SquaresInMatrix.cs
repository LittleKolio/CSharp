using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Exercises032x2SquaresInMatrix
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] matrix = new string[input[0]];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", string.Empty);
            }

            //foreach (string str in matrix)
            //{
            //    Console.WriteLine(str);
            //}

            int[] cell = { 0, 0 };
            int count = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    bool temp = matrix[row][col] == matrix[row][col + 1] &&
                        matrix[row][col] == matrix[row + 1][col] &&
                        matrix[row][col] == matrix[row + 1][col + 1];
                    if (temp)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
