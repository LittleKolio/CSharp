namespace Exam_Retake_3September2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_01_Dangerous_Floor
    {
        public static string[][] board;
        public static void Main()
        {
            MatrixReadNLines(8);

            string input;
            while ((input = Console.ReadLine().Trim()) != "END")
            {
                string[] tokens = SplitInput(input, "-");

                string symbol = tokens[0][0].ToString();
                int[] start =
                {
                    (int)Char.GetNumericValue(tokens[0][1]),
                    (int)Char.GetNumericValue(tokens[0][2])
                };

                int[] end =
                {
                    (int)Char.GetNumericValue(tokens[1][0]),
                    (int)Char.GetNumericValue(tokens[1][1])
                };

                if (board[start[0]][start[1]] != symbol)
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                else if (!IsMoveValide(symbol, start, end))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                else if (end[0] < 0 || end[0] > 7 || end[1] < 0 || end[1] > 7)
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[end[0]][end[1]] = board[start[0]][start[1]];
                board[start[0]][start[1]] = "x";
            }
        }

        private static bool IsMoveValide(string symbol, int[] start, int[] end)
        {
            switch (symbol)
            {
                case "K": return Math.Abs(start[0] - end[0]) <= 1 && Math.Abs(start[1] - end[1]) <= 1;
                case "R": return start[0] == end[0] || start[1] == end[1];
                case "B": return Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]);
                case "Q":
                    return Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]) ||
                  start[0] == end[0] || start[1] == end[1];
                case "P": return start[1] == end[1] && start[0] - end[0] == 1;
                default: return false;
            }
        }

        private static void MatrixReadNLines(int row)
        {
            board = new string[row][];

            for (int r = 0; r < row; r++)
            {
                board[r] = SplitInput(Console.ReadLine(), ",");
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                        StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
