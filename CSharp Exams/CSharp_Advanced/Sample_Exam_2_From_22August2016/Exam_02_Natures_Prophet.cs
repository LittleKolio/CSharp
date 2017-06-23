using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    class Exam_02_Natures_Prophet
    {
        static void Main()
        {
            int[] dimencions = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[dimencions[0]][];
            for (int row = 0; row < dimencions[0]; row++)
            {
                matrix[row] = new int[dimencions[1]];
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow") { break; }

                int[] position = input
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            }
        }
    }
}
