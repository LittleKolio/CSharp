using System;
using System.Collections.Generic;

namespace Stacks_And_Queues_Lab
{
    class Lab_04_Matching_Brackets
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    string str = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(str);
                }
            }
        }
    }
}
