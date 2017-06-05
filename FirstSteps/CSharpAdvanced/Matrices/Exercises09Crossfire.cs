using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Exercises09Crossfire
    {
        public static List<List<int>> matrix;

        static void Main()
        {
            matrix = new List<List<int>>();

            int[] dimMatrix = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            for (int row = 0; row < dimMatrix[0]; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col  < dimMatrix[1]; col++, count++)
                {
                    matrix[row].Add(count);
                }
            }

            //foreach (var row in matrix)
            //{
            //    Console.WriteLine(string.Join(" ", row));
            //}

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Nuke it from orbit") { break; }

                int[] cell = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int r = cell[0];
                int c = cell[1];
                int n = cell[2];

                SelectCell(r, c, n);
                FormatMatrix();
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FormatMatrix()
        {
            for (int row = matrix.Count - 1; row >= 0; row--)
            {
                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                }

                for (int col = matrix[row].Count - 1; col >= 0; col--)
                {
                    if (matrix[row][col] == -1)
                    {
                        matrix[row].RemoveAt(col);
                    }
                }
            }
        }

        private static void SelectCell(int r, int c, int n)
        {
            for (int row = r - n; row <= r + n; row++)
            {
                if (IsCellInMatrix(row, c))
                {
                    matrix[row][c] = -1;
                }
            }

            for (int col = c - n; col <= c + n; col++)
            {
                if (IsCellInMatrix(r, col))
                {
                    matrix[r][col] = -1;
                }
            }
        }

        private static bool IsCellInMatrix(int r, int c)
        {
            if (r >= 0 && r < matrix.Count &&
                c >= 0 && c < matrix[r].Count)
            {
                return true;
            }
            return false;
        }
    }
}
