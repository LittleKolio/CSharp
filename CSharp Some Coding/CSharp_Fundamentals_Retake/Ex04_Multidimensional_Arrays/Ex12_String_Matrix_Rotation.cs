namespace Trash.Ex04_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex12_String_Matrix_Rotation
    {
        public static List<string> matrix;

        public static void Main()
        {
            string input = Console.ReadLine();

            int index = input.IndexOf('(');
            int lengrh = input.Length - (index + 2);

            string sub = input.Substring(index + 1, lengrh);
            int numRot = (int.Parse(sub) / 90) % 4;

            FillList();

            int row = matrix.Count();
            int col = matrix
                .OrderByDescending(str => str.Length)
                .FirstOrDefault()
                .Length;

            switch (numRot)
            {
                case 1: Print_90(row - 1, col - 1); break;
                case 2: Print_180(row - 1, col - 1); break;
                case 3: Print_270(row - 1, col - 1); break;
                case 0: Print_0(); break;
                default: break;
            }

            //Console.ReadKey();
        }

        private static void Print_180(int row, int col)
        {
            for (int r = row; r >= 0; r--)
            {
                for (int c = col; c >= 0; c--)
                {
                    PrintChar(r, c);
                }
                Console.WriteLine();
            }
        }

        private static void Print_90(int row, int col)
        {
            
            for (int c = 0; c <= col; c++)
            {
                for (int r = row; r >= 0; r--)
                {
                    PrintChar(r, c);
                }
                Console.WriteLine();
            }
        }

        private static void Print_270(int row, int col)
        {
            for (int c = col; c >= 0; c--)
            {
                for (int r = 0; r <= row; r++)
                {
                    PrintChar(r, c);
                }
                Console.WriteLine();
            }
        }

        private static void Print_0()
        {
            foreach (string item in matrix)
            {
                Console.WriteLine(item);
            }
        }


        private static void PrintChar(int row, int col)
        {
            char ca;
            try
            {
                ca = matrix[row][col];
            }
            catch
            {
                ca = ' ';
            }
            Console.Write(ca);
        }
        private static void FillList()
        {
            matrix = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                matrix.Add(input);
            }
        }
    }
}
