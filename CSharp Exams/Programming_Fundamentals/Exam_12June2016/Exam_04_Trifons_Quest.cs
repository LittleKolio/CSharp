using System;
using System.Linq;

namespace Exam_12June2016
{
    class Exam_04_Trifons_Quest
    {
        static void Main()
        {
            long helt = long.Parse(Console.ReadLine());
            int[] size = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            char[][] matrix = new char[size[0]][];
            for (int r = 0; r < size[0]; r++)
            {
                matrix[r] = Console.ReadLine()
                    .ToArray();
            }
            ////foreach (var item in matrix) {
            ////    Console.WriteLine (string.Join (" ", item));
            ////}
            int count = 0;
            bool death = false;

            int row = 0;
            int revers = 1;
            for (int col = 0; col < size[1]; col++)
            {
                while (true)
                {
                    if (row >= size[0] || row <= -1)
                        break;
                    switch (matrix[row][col])
                    {
                        case 'F':
                            helt -= count / 2;
                            count++;
                            break;
                        case 'H':
                            helt += count / 3;
                            count++;
                            break;
                        case 'T':
                            count += 3;
                            break;
                        case 'E':
                            count++;
                            break;
                    }
                    if (helt <= 0)
                    {
                        Console.WriteLine("Died at: [{0}, {1}]", row, col);
                        return;
                    }
                    row += revers;
                }
                revers *= -1;
                row += revers;
            }
            Console.WriteLine("Quest completed!");
            Console.WriteLine("Health: {0}", helt);
            Console.WriteLine("Turns: {0}", count);
        }
    }
}
