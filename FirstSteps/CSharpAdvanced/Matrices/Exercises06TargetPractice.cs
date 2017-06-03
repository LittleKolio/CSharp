using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Exercises06TargetPractice
    {
        static void Main()
        {
            int[] dim = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();

            int[] shot = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[][] matrix = new char[dim[0]][];

            int count = 0;
            for (int row = matrix.Length - 1, direction = -1;
                row >= 0; 
                row--, direction *= -1)
            {
                matrix[row] = new char[dim[1]];

                for (int col = 0; col < matrix[row].Length; col++, count++)
                {
                    matrix[row][col] = snake[count % snake.Length];
                }

                if (direction < 0)
                { matrix[row] = matrix[row].Reverse().ToArray(); }
            }

            int rStart = Math.Max(
                shot[0] - shot[2], 0);
            int rEnd = Math.Min(
                shot[0] + shot[2], 
                matrix.Length - 1);

            for (int row = rStart; row <= rEnd; row++)
            {
                int offset = Math.Abs(shot[0] - row);
                int cStart = Math.Max(
                    shot[1] - shot[2] + offset, 0);
                int cEnd = Math.Min(
                    shot[1] + shot[2] - offset,
                    matrix[0].Length - 1);

                for (int col = cStart ; 
                    col <= cEnd; 
                    col++)
                {
                    matrix[row][col] = ' ';
                }
            }

            int cStartReroll = Math.Max(
                shot[1] - shot[2], 0);
            int cEndReroll = Math.Min(
                shot[1] + shot[2],
                matrix[0].Length - 1);

            for (int row = rStart; row <= rEnd; row++)
            {
                for (int col = cStartReroll; col <= cEndReroll; col++)
                {
                    if (matrix[row][col] == ' ' && row > 0)
                    {
                        for (int reroll = row; reroll > 0; reroll--)
                        {
                            if (matrix[reroll - 1][col] == ' ') { break; }

                            matrix[reroll][col] = matrix[reroll - 1][col];
                            matrix[reroll - 1][col] = ' ';
                        }
                    }
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }
    }
}
