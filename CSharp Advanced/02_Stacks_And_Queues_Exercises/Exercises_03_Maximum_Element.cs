﻿namespace Stacks_And_Queues_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Exercises03MaximumElement
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            maxNumbers.Push(0);

            //string input;
            //while (!string.IsNullOrEmpty(input = Console.ReadLine())) { }

            for (int i = 0; i < input; i++)
            {
                int[] query = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (query[0])
                {
                    case 1:
                        {
                            stack.Push(query[1]);
                            if (query[1] > maxNumbers.Peek())
                            {
                                maxNumbers.Push(query[1]);
                            }
                        }
                        break;
                    case 2:
                        {
                            if (stack.Pop() == maxNumbers.Peek())
                            {
                                maxNumbers.Pop();
                            }
                        }
                        break;
                    case 3: Console.WriteLine(maxNumbers.Peek()); break;
                    default:
                        break;
                }
            }
        }
    }
}
