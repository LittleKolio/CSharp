namespace Trash.CSharp_Advanced_Exam_25June2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam02_Knight_Game
    {
        public static char[][] board;
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            board = new char[size][];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine().Trim();

                //if (line.Length != size)
                //    throw new ArgumentOutOfRangeException();

                board[row] = line.ToCharArray();
            }

            int count = 0;
            int[] knight;
            while ((knight = TraverseBoard(size)) != null)
            {

                board[knight[0]][knight[1]] = '0';
                count++;

                //Console.WriteLine(new string('-', size * 2 - 1));
                //foreach (var line in board)
                //{
                //    Console.WriteLine(string.Join(" ", line));
                //    Console.WriteLine();
                //}
            }

            Console.WriteLine(count);
        }

        private static int[] TraverseBoard(int size)
        {
            int attacks = 0;
            int[] knight = null;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (IsKnight(row, col))
                    {
                        int currentAttacks = Attacks(row, col);
                        if (attacks < currentAttacks)
                        {
                            knight = new int[] { row, col };
                            attacks = currentAttacks;
                        }
                    }
                }
            }

            return knight;
        }

        private static int Attacks(int row, int col)
        {
            int count = 0;

            if (InBoard(row - 1, col - 2) && IsKnight(row - 1, col - 2)) { count++; }
            if (InBoard(row - 2, col - 1) && IsKnight(row - 2, col - 1)) { count++; }
            if (InBoard(row - 2, col + 1) && IsKnight(row - 2, col + 1)) { count++; }
            if (InBoard(row - 1, col + 2) && IsKnight(row - 1, col + 2)) { count++; }
            if (InBoard(row + 1, col + 2) && IsKnight(row + 1, col + 2)) { count++; }
            if (InBoard(row + 2, col + 1) && IsKnight(row + 2, col + 1)) { count++; }
            if (InBoard(row + 2, col - 1) && IsKnight(row + 2, col - 1)) { count++; }
            if (InBoard(row + 1, col - 2) && IsKnight(row + 1, col - 2)) { count++; }

            return count;
        }

        private static bool IsKnight(int row, int col)
        {
            return board[row][col] == 'K';
        }

        private static bool InBoard(int row, int col)
        {
            int r = board.Length;
            int c = board[0].Length;

            bool inRow = 0 <= row && row < r;
            bool inCol = 0 <= col && col < c;

            return inRow && inCol;
        }
    }
}
