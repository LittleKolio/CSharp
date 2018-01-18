namespace Exercise_07_Distance_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Const.size = num;

            Matrix matrix = new Matrix();
            matrix.MatrixReadNLines();

            List<Cell> position = matrix.FindSymbols('*');
            Cell start = position[0];
            start.Value = 0;

            Queue<Cell> listOfCells = new Queue<Cell>();
            listOfCells.Enqueue(start);

            while (listOfCells.Count > 0)
            {
                Cell cell = listOfCells.Dequeue();

                int r = cell.Row;
                int c = cell.Col;
                int v = cell.Value;

                if (matrix.ChangeCell(r, c, v.ToString(), '0') || v == 0)
                {
                    try { listOfCells.Enqueue(new Cell(r - 1, c, v + 1)); }
                    catch { }

                    try { listOfCells.Enqueue(new Cell(r, c - 1, v + 1)); }
                    catch { }

                    try { listOfCells.Enqueue(new Cell(r + 1, c, v + 1)); }
                    catch { }

                    try { listOfCells.Enqueue(new Cell(r, c + 1, v + 1)); }
                    catch { }
                }
            }

            List<Cell> lastCells = matrix.FindSymbols('0');
            foreach (Cell cell in lastCells)
            {
                matrix.ChangeCell(
                    cell.Row, 
                    cell.Col, 
                    "u", 
                    '0');
            }

            matrix.PrintMatrix();
        }
    }


    public static class Const
    {
        public static int size;
    }

        public class Cell
    {
        private int row;
        private int col;

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

        public int Row
        {
            get { return this.row; }
            set
            {
                if (value < 0 || value > Const.size - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.row = value;
            }
        }

        public int Col
        {
            get { return this.col; }
            set
            {
                if (value < 0 || value > Const.size - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.col = value;
            }
        }
        public int Value { get; set; }
    }

    public class Matrix
    {
        private string[] matrix;

        public Matrix()
        {
            this.matrix = new string[Const.size];
        }

        public bool ChangeCell(int r, int c, string v, char symbol)
        {
            bool success = false;

            if (this.matrix[r][c] == symbol)
            {
                string str = this.matrix[r]
                    .Remove(c, 1)
                    .Insert(c, v);

                this.matrix[r] = str;

                success = true;
            }

            return success;
        }

        public List<Cell> FindSymbols(char symbol)
        {
            List<Cell> cells = new List<Cell>();

            for (int r = 0; r < Const.size; r++)
            {
                string line = this.matrix[r];
                int c = 0;
                while ((c = line.IndexOf(symbol, c)) != -1)
                {
                    cells.Add(new Cell(r, c));
                    c++;
                }
            }

            return cells;
        }

        public void MatrixReadNLines()
        {
            for (var r = 0; r < Const.size; r++)
            {
                string line = Console.ReadLine();
                if (line.Length != Const.size)
                {
                    throw new FormatException();
                }
                this.matrix[r] = line;
            }
        }

        public void PrintMatrix()
        {
            foreach (string line in this.matrix)
            {
                Console.WriteLine(line);
            }
        }
    }
}
