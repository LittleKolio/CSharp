using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced.WorkingWithStacks
{
    class Exercises03MaximumElement
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxNumbers = new Stack<int>();
            int maxValue = int.MinValue;

            for (int i = 0; i < input; i++)
            {
                int[] query = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (query[0] == 1)
                {
                    stack.Push(query[1]);
                    if (query[1] > maxValue)
                    {
                        maxValue = query[1];
                        maxNumbers.Push(maxValue);
                    }
                }

                if (query[0] == 2)
                {
                    if (stack.Pop() == maxValue)
                    {
                        maxNumbers.Pop();
                        if (maxNumbers.Count != 0)
                        {
                            maxValue = maxNumbers.Peek();
                        }
                        else
                        {
                            maxValue = int.MinValue;
                        }
                    }
                }

                if (query[0] == 3)
                {
                    Console.WriteLine(maxValue);
                }
            }
        }
    }
}
