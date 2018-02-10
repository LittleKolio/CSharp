namespace Exam_Retake_3September2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The board is 8x8 squares. There are 6 kinds of pieces: 
    /// King - moves exactly one square horizontally, vertically, or diagonally. 
    /// Rook- moves any number of vacant squares in a horizontal or vertical direction. 
    /// Bishop - moves any number of vacant squares in any diagonal direction. 
    /// Queen - moves any number of vacant squares in a horizontal, vertical, or diagonal direction. 
    /// Pawn – moves straight forward one square to the top.
    /// On the first 8 rows, you will receive а board with some pieces placed on it. 
    /// Empty cells will be marked with "x" and all squares will be separated by comma.
    /// x,x,Q,x,R,x,x,P
    /// ...
    /// On the next lines, you will receive moves Q01-12.
    /// The first symbol is the type, two digits ar the position (row, col). 
    /// The next two digits are the final position (row, col).
    /// The moves need to be checked in the very same order as shown below:
    /// 1 There is no such a piece on square.
    /// 2 Piece makes invalid move (look above).
    /// 3 Piece gets out of board.
    /// </summary>
    /// <output>
    /// You should print only one message depending on the problem.
    /// There is no such a piece!
    /// Invalid move!
    /// Move go out of board!
    /// </output>
    /// <remarks>
    /// Moves count will be in the range [0…1000]
    /// Time limit: 0.3 sec.
    /// Memory limit: 16 MB.
    /// </remarks>

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
