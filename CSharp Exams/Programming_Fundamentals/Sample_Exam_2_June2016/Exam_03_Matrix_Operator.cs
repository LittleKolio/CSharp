using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample_Exam_2_June2016
{
    class Exam_03_Matrix_Operator
    {
        public static void Main()
        {
            int row = int.Parse(Console.ReadLine());
            List<List<int>> matrix = new List<List<int>>();
            for (int r = 0; r < row; r++)
            {
                matrix.Add(Console.ReadLine()
                  .Split(' ')
                  .Select(int.Parse)
                  .ToList());
            }
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(' ');
                if (commands[0] == "end")
                    break;

                switch (commands[0])
                {
                    case "remove":
                        {
                            int num = int.Parse(commands[3]);
                            string com = commands[2];

                            switch (commands[1])
                            {
                                case "positive":
                                    {
                                        Func<int, bool> f = (x) => x >= 0;
                                        RemoveElement(matrix, com, num, f);
                                    }
                                    break;
                                case "negative":
                                    {
                                        Func<int, bool> f = (x) => x < 0;
                                        RemoveElement(matrix, com, num, f);
                                    }
                                    break;
                                case "odd":
                                    {
                                        Func<int, bool> f = (x) => x % 2 != 0;
                                        RemoveElement(matrix, com, num, f);
                                    }
                                    break;
                                case "even":
                                    {
                                        Func<int, bool> f = (x) => x % 2 == 0;
                                        RemoveElement(matrix, com, num, f);
                                    }
                                    break;
                                default: break;
                            }
                        }
                        break;
                    case "swap":
                        {
                            int row1 = int.Parse(commands[1]);
                            int row2 = int.Parse(commands[2]);
                            List<int> old = matrix[row1];
                            matrix[row1] = matrix[row2];
                            matrix[row2] = old;
                        }
                        break;
                    case "insert":
                        {
                            int row1 = int.Parse(commands[1]);
                            int num = int.Parse(commands[2]);
                            matrix[row1].Insert(0, num);
                        }
                        break;
                    default: break;
                }
            }
            Print(matrix);
        }

        private static void RemoveElement(List<List<int>> matrix, string com, int num, Func<int, bool> f)
        {
            if (com == "row")
            {
                matrix[num].RemoveAll(x => f(x));
            }
            else if (com == "col")
            {
                for (int r = 0; r < matrix.Count && num < matrix[r].Count; r++)
                {
                    if (f(matrix[r][num]))
                        matrix[r].RemoveAt(num);
                }
            }
        }
        static void Print(List<List<int>> matrix)
        {
            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
