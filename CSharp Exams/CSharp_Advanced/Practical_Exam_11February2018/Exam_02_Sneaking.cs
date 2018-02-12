namespace Practical_Exam_11February2018
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam_02_Sneaking
    {

        public static char[][] room;
        public static int[] sam;

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            MatrixReadNLines(size);

            string moves = Console.ReadLine();

            for (int move = 0; move < moves.Length; move++)
            {
                EnemieMove();
                if (KillSam())
                {
                    Console.WriteLine($"Sam died at {sam[0]}, {sam[1]}");
                    break;
                }
                //PrintRoom();
                SamMove(moves[move]);
                if (Killer())
                {
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
                //PrintRoom();
            }
            PrintRoom();
        }

        private static void SamMove(char move)
        {
            room[sam[0]][sam[1]] = '.';
            switch (move)
            {
                case 'U': sam[0] -= 1; break;
                case 'D': sam[0] += 1; break;
                case 'L': sam[1] -= 1; break;
                case 'R': sam[1] += 1; break;
                default:
                    break;
            }
        }

        private static bool KillSam()
        {
            int row = sam[0];
            for (int col = 0; col < room[row].Length; col++)
            {
                if ((room[row][col] == 'b' && col < sam[1]) ||
                    (room[row][col] == 'd' && col > sam[1]))
                {
                    room[row][sam[1]] = 'X';
                    return true;
                }
            }
            return false;
        }

        private static bool Killer()
        {
            int row = sam[0];
            bool isKiller = false;
            for (int col = 0; col < room[row].Length; col++)
            {
                if (room[row][col] == 'N')
                {
                    room[row][col] = 'X';
                    isKiller = true;
                    break;
                }
            }

            room[sam[0]][sam[1]] = 'S';

            return isKiller;
        }

        private static void EnemieMove()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    char c = room[row][col];
                    switch (c)
                    {
                        case 'b':
                            {
                                if (col == room[row].Length - 1)
                                {
                                    room[row][col] = 'd';
                                }
                                else
                                {
                                    room[row][col] = '.';
                                    room[row][col + 1] = 'b';
                                    col++;
                                }
                                break;
                            }
                        case 'd':
                            {
                                if (col == 0)
                                {
                                    room[row][col] = 'b';
                                }
                                else
                                {
                                    room[row][col] = '.';
                                    room[row][col - 1] = 'd';
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }

        }

        private static void PrintRoom()
        {
            foreach (var line in room)
            {
                Console.WriteLine(string.Join("", line));
            }
        }

        private static void MatrixReadNLines(int row)
        {
            room = new char[row][];

            for (int r = 0; r < row; r++)
            {
                string input = Console.ReadLine();
                int indexOfSam = input.IndexOf('S');
                if (indexOfSam >= 0)
                {
                    sam = new int[] { r, indexOfSam };
                }
                room[r] = input.ToCharArray();
            }
        }
    }
}
