﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.WorkingWithStacks
{
    class Exercises07BalancedParentheses
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if ("{[(".Contains(input[i]))
                {
                    parentheses.Push(input[i]);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (input[i])
                    {
                        case ')':
                            if (parentheses.Pop() != '(')
                            { Console.WriteLine("NO"); return; }
                            break;
                        case ']':
                            if (parentheses.Pop() != '[')
                            { Console.WriteLine("NO"); return; }
                            break;
                        case '}':
                            if (parentheses.Pop() != '{')
                            { Console.WriteLine("NO"); return; }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}
