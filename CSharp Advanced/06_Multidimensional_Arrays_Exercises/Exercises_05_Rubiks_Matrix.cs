using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays_Exercises
{
    class Exercises_05_Rubiks_Matrix
    {
        static int[][] matrix;

        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = new int[input[0]][];
            int num = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[input[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = num++;
                }
            }

            int commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                string[] command = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                int index = int.Parse(command[0]);
                int pitch = int.Parse(command[2]);
                int pitchDown = matrix.Length - pitch % matrix.Length;
                int pitchRight = matrix[index].Length - pitch % matrix[index].Length;

                switch (command[1])
                {
                    case "up": UpAndDown(index, pitch); break;
                    case "down": UpAndDown(index, pitchDown); break;
                    case "left": LeftAndRight(index, pitch); break;
                    case "right": LeftAndRight(index, pitchRight); break;
                }
            }

            num = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    num++;

                    if (matrix[row][col] == num)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int[] swap = Search(num);
                        int tempCell = matrix[swap[0]][swap[1]];
                        matrix[swap[0]][swap[1]] = matrix[row][col];
                        matrix[row][col] = tempCell;

                        Console.WriteLine($"Swap ({row}, {col}) with ({swap[0]}, {swap[1]})");
                    }
                }
            }
        }

        private static int[] Search(int num)
        {
            int[] temp = { 0, 0 };
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == num)
                    {
                        temp[0] = row;
                        temp[1] = col;
                        return temp;
                    }
                }
            }
            return temp;
        }

        private static void LeftAndRight(int r, int n)
        {
            int[] temp = new int[matrix[r].Length];
            for (int col = 0; col < matrix[r].Length; col++)
            {
                temp[col] = matrix[r][(col + n) % matrix[r].Length];
            }

            matrix[r] = temp;
        }

        private static void UpAndDown(int c, int n)
        {
            int[] temp = new int[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                temp[row] = matrix[(row + n) % matrix.Length][c];
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row][c] = temp[row];
            }
        }
    }
}
