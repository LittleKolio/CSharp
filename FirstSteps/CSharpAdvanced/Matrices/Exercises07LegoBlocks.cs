using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Matrices
{
    class Exercises07LegoBlocks
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            int[][] first = new int[num][];
            int[][] second = new int[num][];

            for (int row = 0; row < num; row++)
            {
                first[row] = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            for (int row = 0; row < num; row++)
            {
                second[row] = Console.ReadLine()
                .Split(
                    new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            }

            int length = first[0].Length + second[0].Length;
            bool fit = true;
            int countCells = 0;

            for (int row = 0; row < num; row++)
            {
                countCells += (first[row].Length + second[row].Length);
                if (countCells % length != 0)
                {
                    fit = false;
                }
            }

            if (fit)
            {
                int[][] result = new int[num][];
                for (int row = 0; row < num; row++)
                {
                    result[row] = new int[length];
                    Array.Copy(first[row], result[row], first[row].Length);
                    Array.Copy(
                        second[row], 0, 
                        result[row], first[row].Length, 
                        second[row].Length);
                }
                foreach (var row in result)
                {
                    Console.Write("[");
                    Console.Write(string.Join(", ", row));
                    Console.WriteLine("]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {countCells}");
            }
        }
    }
}
