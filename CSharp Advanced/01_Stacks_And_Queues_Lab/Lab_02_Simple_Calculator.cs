using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_And_Queues_Lab
{
    class Lab_02_Simple_Calculator
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            // .Split(' ').Reverse() is not string[]
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string op = stack.Pop();
                int second = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else
                {
                    stack.Push((first - second).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
