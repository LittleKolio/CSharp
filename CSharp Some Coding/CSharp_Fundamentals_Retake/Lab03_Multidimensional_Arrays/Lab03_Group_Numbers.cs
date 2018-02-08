namespace Trash.Lab03_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab03_Group_Numbers
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int[] arr = SplitInput(input, ", ");

            List<int>[] matrix = MatrixReadNLines(arr);

            foreach (List<int> list in matrix)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static int[] SplitInput(string input, string delimiter)
        {
            return input
                .Split(delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static List<int>[] MatrixReadNLines(int[] arr, int row = 3)
        {
            List<int>[] matrix = new List<int>[row];

            for (var col = 0; col < arr.Length; col++)
            {
                int num = arr[col];
                int index = Math.Abs(num) % 3;

                if (matrix[index] == null)
                {
                    matrix[index] = new List<int>();
                }

                matrix[index].Add(num);
            }

            return matrix;
        }
    }
}
