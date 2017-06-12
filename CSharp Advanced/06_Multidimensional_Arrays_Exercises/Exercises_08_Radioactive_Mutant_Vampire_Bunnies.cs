using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays_Exercises
{
    public class Exercises_08_Radioactive_Mutant_Vampire_Bunnies
    {
        // Initial offset/pitch/radius for bunnies multiplication
        const int offIn = 1;
        const char bunnie = 'B';
        const char player = 'P';

        static string[] matrixLair;
        static List<int[]> bunnies;
        static int[] pCell;
        static bool death;
        static bool won;

        static void Main()
        {
            bunnies = new List<int[]>();
            death = false;
            won = false;
            pCell = new int[2];

            int[] num = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrixLair = new string[num[0]];

            for (int row = 0; row < num[0]; row++)
            {
                matrixLair[row] = Console.ReadLine();
                int index = matrixLair[row].IndexOf(player);
                if (index != -1)
                {
                    pCell[0] = row;
                    pCell[1] = index;
                }
            }

            string moves = Console.ReadLine();

            PlayerMove(moves, num);

            PintResult();
        }

        private static void PintResult()
        {
            foreach (var str in matrixLair)
            {
                //Console.WriteLine(string.Join(" ", str.ToArray()));
                Console.WriteLine(str);
            }
            if (death) { Console.WriteLine($"dead: {pCell[0]} {pCell[1]}"); }
            else { Console.WriteLine($"won: {pCell[0]} {pCell[1]}"); }
        }

        private static void PlayerMove(string moves, int[] num)
        {
            for (int step = 0; step < moves.Length; step++)
            {
                switch (moves[step])
                {
                    case 'U': PlayerStep(pCell[0] - 1, pCell[1]); break;
                    case 'D': PlayerStep(pCell[0] + 1, pCell[1]); break;
                    case 'R': PlayerStep(pCell[0], pCell[1] + 1); break;
                    case 'L': PlayerStep(pCell[0], pCell[1] - 1); break;
                }

                BunniesList(num);
                BunniesMultiplication();

                if (death || won) { return; }
            }
        }

        private static void PlayerStep(int row, int col)
        {
            matrixLair[pCell[0]] = matrixLair[pCell[0]]
                .Remove(pCell[1], 1)
                .Insert(pCell[1], ".");

            try
            {
                // Is bunnie
                if (matrixLair[row][col] == bunnie)
                { death = true; }
            }
            catch { won = true; }

            if (won) { return; }
            else if (death)
            {
                pCell[0] = row;
                pCell[1] = col;
                return;
            }
            else
            {
                matrixLair[row] = matrixLair[row]
                    .Remove(col, 1)
                    .Insert(col, player.ToString());

                pCell[0] = row;
                pCell[1] = col;
            }
        }

        private static void BunniesMultiplication()
        {
            foreach (var cell in bunnies)
            {
                int rStart = Math.Max(cell[0] - offIn, 0);
                int rEnd = Math.Min(cell[0] + offIn, matrixLair.Length - 1);

                for (int row = rStart; row <= rEnd; row++)
                {
                    int offset = Math.Abs(cell[0] - row);
                    int cStart = Math.Max(cell[1] - offIn + offset, 0);
                    int cEnd = Math.Min(
                        cell[1] + offIn - offset,
                        matrixLair[cell[0]].Length - 1);

                    for (int col = cStart; col <= cEnd; col++)
                    {
                        if (matrixLair[row][col] == player)
                        {
                            death = true;
                            return;
                        }

                        matrixLair[row] = matrixLair[row]
                            .Remove(col, 1)
                            .Insert(col, bunnie.ToString());
                    }
                }
            }
        }

        private static void BunniesList(int[] num)
        {
            for (int row = 0; row < num[0]; row++)
            {
                int index = matrixLair[row].IndexOf(bunnie);
                while (index != -1)
                {
                    bunnies.Add(new int[] { row, index });
                    index = matrixLair[row].IndexOf(bunnie, index + 1);
                }
            }
        }
    }
}
