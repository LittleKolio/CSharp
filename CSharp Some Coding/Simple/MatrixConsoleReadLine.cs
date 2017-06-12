namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixConsoleReadLine
    {
        private static int[,] MatrixReadNLines()
        {
            int[,] matrix = new int[5, 5];

            for (var row = 0; row < 5; row++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (line.Length != 5)
                    throw new FormatException();

                for (var col = 0; col < 5; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            return matrix;
        }


        private static int[,] MatrixReadSingleLine()
        {
            int[,] matrix = new int[5, 5];
            string line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
                throw new FormatException();

            int[] lineArray = line
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            if (lineArray.Length != 25)
                throw new FormatException();

            for (var element = 0; element < 25; element++)
            {
                matrix[element / 5, element % 5] = lineArray[element];
            }
            return matrix;
        }
    }
}
