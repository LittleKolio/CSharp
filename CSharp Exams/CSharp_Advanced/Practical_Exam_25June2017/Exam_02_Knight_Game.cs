using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Exam_25June2017
{
    /// <summary>
    /// For this task we will use only one chess piece - the Knight.
    /// On the first line, you will receive the N size of the board.
    /// On the next N lines you will receive strings with K for knights and '0' for empty cells.
    /// Your task is to remove a minimum of the knights, so there will be no knights left that can attack another knight.
    /// </summary>
    /// <output>
    /// Print a single integer with the minimum amount of knights that needs to be removed.
    /// </output>
    /// <remarks>
    /// Size of the board will be 0 < N < 30
    /// Time limit: 0.3 sec. Memory limit: 16 MB.
    /// </remarks>
    class Exam_02_Knight_Game
    {
        static void Main()
        {
            int dim = int.Parse(Console.ReadLine());

            string[] matrix = new string[dim];
            for (int i = 0; i < dim; i++)
            {
                matrix[i] = Console.ReadLine();
            }

            int result = 0;
            while (true)
            {
                int[] cell = { 0, 0 };
                int countK = 0;

                for (int row = 0; row < dim; row++)
                {
                    for (int col = 0; col < dim; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            int num = CheckCell(row, col, matrix);
                            if (num > countK)
                            {
                                countK = num;
                                cell[0] = row;
                                cell[1] = col;
                            }
                        }
                    }
                }

                if (countK == 0) { break; }

                matrix[cell[0]] = matrix[cell[0]].Remove(cell[1], 1).Insert(cell[1], "0");

                result++;

                //Console.WriteLine();
                //foreach (var row in matrix)
                //{
                //    Console.WriteLine(string.Join(" ", row));
                //}
            }

            Console.WriteLine(result);
        }

        private static int CheckCell(int row, int col, string[] matrix)
        {
            int count = 0;

            try { if (matrix[row + 1][col + 2] == 'K') { count++; }; } catch { }
            try { if (matrix[row + 1][col - 2] == 'K') { count++; }; } catch { }
            try { if (matrix[row - 1][col + 2] == 'K') { count++; }; } catch { }
            try { if (matrix[row - 1][col - 2] == 'K') { count++; }; } catch { }
            try { if (matrix[row + 2][col + 1] == 'K') { count++; }; } catch { }
            try { if (matrix[row + 2][col - 1] == 'K') { count++; }; } catch { }
            try { if (matrix[row - 2][col + 1] == 'K') { count++; }; } catch { }
            try { if (matrix[row - 2][col - 1] == 'K') { count++; }; } catch { }

            return count;
        }
    }
}
