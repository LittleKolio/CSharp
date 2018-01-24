using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues_Exercises
{
    class Exercises_01_Reverse_Numbers
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(input);
            Console.WriteLine(string.Join(" ", stack));

            //string input = Console.ReadLine();
            //if (input != string.Empty)
            //{
            //    Stack<int> stack = new Stack<int>(
            //        input.Split(new char[] { ' ' }, 
            //            StringSplitOptions.RemoveEmptyEntries)
            //        .Select(int.Parse));

            //    while (stack.Count > 0)
            //    {
            //        Console.Write(stack.Pop() + " ");
            //    }
            //}


        }
    }
}
