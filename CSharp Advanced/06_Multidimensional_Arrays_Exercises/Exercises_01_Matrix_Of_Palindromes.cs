using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays_Exercises
{
    class Exercises_01_Matrix_Of_Palindromes
    {
        static void Main()
        {
            // ElapsedTicks => Concat() > "" +

            int[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[][] matrix = new string[input[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[input[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = "" +
                        chars[row % chars.Length] + 
                        chars[(row + col) % chars.Length] + 
                        chars[row % chars.Length];

                    //matrix[row][col] = String.Concat(new[] 
                    //{
                    //    chars[row % chars.Length],
                    //    chars[(row + col) % chars.Length],
                    //    chars[row % chars.Length]
                    //});
                }
            }

            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);

            foreach (string[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
