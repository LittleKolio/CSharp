using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues_Exercises
{
    class Exercises_02_Basic_Stack_Operations
    {
        static void Main()
        {
            // Number of opperations
            // [0] - enqueue
            // [1] - dequeue
            // whether contains [2] = element
            int[] opp = Console.ReadLine()
                .Split(new[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            // Sequence of numbers
            int[] seq = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < opp[0]; i++)
            {
                int index = i % seq.Length;
                stack.Push(seq[index]);
            }

            for (int i = 0; i < opp[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Count != 0)
            {
                if (stack.Contains(opp[2]))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
