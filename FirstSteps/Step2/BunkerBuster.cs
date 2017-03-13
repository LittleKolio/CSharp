using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step2
{
    class BunkerBuster
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(input[0] + " " + input[1]);

            int[,] area = new int[input[0], input[1]];
            for (int r = 0; r < input[0]; r++)
            {
                int[] temp = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < input[1]; c++)
                {
                    area[r, c] = temp[c];
                }
            }

            for (int r = 0; r < input[0]; r++)
            {
                for (int c = 0; c < input[1]; c++)
                {
                    Console.Write(area[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
