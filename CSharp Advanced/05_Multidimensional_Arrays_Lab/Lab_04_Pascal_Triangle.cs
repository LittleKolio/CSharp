﻿namespace Multidimensional_Arrays_Lab
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab_04_Pascal_Triangle
    {
        private static int input;

        public static void Main()
        {
            input = int.Parse(Console.ReadLine());

            long[] arr = { 1 };
            Console.WriteLine(string.Join(" ", arr));

            Triangle(arr);

            /*
            long[][] triangle = new long[input][];

            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                triangle[row][triangle[row].Length - 1] = 1;

                for (int col = 1; col < triangle[row].Length - 1; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
            }

            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
            */
        }

        private static void Triangle(long[] arr)
        {
            if (arr.Length == input)
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
