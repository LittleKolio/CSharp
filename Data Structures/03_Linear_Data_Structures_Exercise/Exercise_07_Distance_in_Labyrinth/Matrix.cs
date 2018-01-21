namespace Exercise_07_Distance_in_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            Matrix.size = size;

            int[][] matrix = new int[size][];
            Cell start = Matrix.MatrixReadNLines(matrix);

            Queue<Cell> listOfCells = new Queue<Cell>();
            listOfCells.Enqueue(start);

            while (listOfCells.Count > 0)
            {
                Cell cell = listOfCells.Dequeue();

                int row = cell.Row;
                int col = cell.Col;
                int value = cell.Value;

                Cell up = Matrix.CheckCell(matrix, row - 1, col, value + 1);
                if (up != null)
                {
                    listOfCells.Enqueue(up);
                }

                Cell left = Matrix.CheckCell(matrix, row, col - 1, value + 1);
                if (left != null)
                {
                    listOfCells.Enqueue(left);
                }

                Cell down = Matrix.CheckCell(matrix, row + 1, col, value + 1);
                if (down != null)
                {
                    listOfCells.Enqueue(down);
                }

                Cell right = Matrix.CheckCell(matrix, row, col + 1, value + 1);
                if (right != null)
                {
                    listOfCells.Enqueue(right);
                }

            }

            Matrix.PrintMatrix(matrix);
        }
    }

    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public Cell(int row, int col, int value)
            : this (row, col)
        {
            this.Value = value;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Value { get; set; }
    }

    public static class Matrix
    {
        public static int size;

        public static Cell CheckCell(
            int[][] matrix, 
            int row,
            int col,
            int value)
        {
            Cell cell = null;

            bool inRow = row >= 0 && row < size;
            bool inCol = col >= 0 && col < size;

            if (inRow && inCol && matrix[row][col] == 0)
            {
                cell = new Cell(row, col, value);
                matrix[row][col] = value;
            }

            return cell;
        }

        public static Cell MatrixReadNLines(int[][] matrix)
        {
            Cell start = null;

            for (var r = 0; r < size; r++)
            {
                string line = Console.ReadLine();

                if (line.Length != size)
                {
                    throw new FormatException();
                }

                matrix[r] = new int[size];

                for (int c = 0; c < size; c++)
                {
                    char symbol = line[c];

                    if (symbol == 'x')
                    {
                        matrix[r][c] = -2;
                    }
                    else if (symbol == '*')
                    {
                        matrix[r][c] = -1;
                        start = new Cell(r, c, 0);
                    }
                    else
                    {
                        matrix[r][c] = 0;
                    }
                }
            }

            return start;
        }

        public static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] line in matrix)
            {
                StringBuilder sb = new StringBuilder();

                foreach (int num in line)
                {
                    if (num == -1)
                    {
                        sb.Append('*');
                    }
                    else if (num == -2)
                    {
                        sb.Append('x');
                    }
                    else if (num == 0)
                    {
                        sb.Append('u');
                    }
                    else
                    {
                        sb.Append(num);
                    }
                }

                Console.WriteLine(sb);
            }
        }
    }
}
