namespace Trash.Ex04_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex01_Matrix_of_Palindromes
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int row = nums[0];
            int col = nums[1];

            string[][] matrix = new string[row][];

            char start = 'a';

            for (int i = 0; i < row; i++)
            {
                matrix[i] = new string[col];

                for (int j = 0; j < col; j++)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append(Convert.ToChar(start + i));
                    str.Append(Convert.ToChar(start + i +j));
                    str.Append(Convert.ToChar(start + i));
                    matrix[i][j] = str.ToString();
                }

                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
