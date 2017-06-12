using System;
using System.Collections.Generic;

namespace Stacks_And_Queues_Lab
{
    public class Lab_01_Reverse_Strings
    {
        public static void Main()
        {
            //char[] input = Console.ReadLine().ToCharArray();
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
