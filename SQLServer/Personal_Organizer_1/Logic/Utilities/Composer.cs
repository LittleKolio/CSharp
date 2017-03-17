﻿namespace Logic.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Composer
    {
        public static char[][] GetBox(int width, int height)
        {
            var matrix = new char[height][];

            for (int row = 0; row < height; row++)
            {
                matrix[row] = new char[width];
                for (int col = 0; col < width; col++)
                {
                    if (row == 0)
                    {
                        if (col == 0) { matrix[row][col] = (char)9556; }
                        else if (col == width - 1) { matrix[row][col] = (char)9559; }
                        else { matrix[row][col] = (char)9552; }
                    }
                    else if (row == height - 1)
                    {
                        if (col == 0) { matrix[row][col] = (char)9562; }
                        else if (col == width - 1) { matrix[row][col] = (char)9565; }
                        else { matrix[row][col] = (char)9552; }
                    }
                    else if (col == 0 || col == width - 1)
                    {
                        matrix[row][col] = (char)9553;
                    }
                    else
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
            return matrix;
        }

        public static string[] Compose(char[][] matrix)
        {
            var layout = new string[matrix.Length];
            for (int row = 0; row < matrix.Length; row++)
            {
                layout[row] = string.Join("", matrix[row]);
            }
            return layout;
        }
    }
}
