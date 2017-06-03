using System;
using System.Collections.Generic;

namespace CSharpAdvanced.WorkingWithStacks
{
    class Lab04MatchingBrackets
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
