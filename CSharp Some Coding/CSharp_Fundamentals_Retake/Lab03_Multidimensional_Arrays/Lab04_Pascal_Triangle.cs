namespace Trash.Lab03_Multidimensional_Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab04_Pascal_Triangle
    {
        private static int depth;
        public static void Main()
        {
            depth = int.Parse(Console.ReadLine());

            long[] arr = { 1 };
            Console.WriteLine(string.Join(" ", arr));

            Triangle(arr);
        }

        private static void Triangle(long[] arr)
        {
            if (arr.Length == depth)
            {
                return;
            }

            long[] newArr = new long[arr.Length + 1];

            for (int i = 0; i < newArr.Length; i++)
            {
                long num = 0;

                if (i - 1 >= 0)
                {
                    num += arr[i - 1];
                }

                if (i < arr.Length)
                {
                    num += arr[i];
                }

                newArr[i] = num;
            }

            Console.WriteLine(string.Join(" ", newArr));

            Triangle(newArr);
        }
    }
}
