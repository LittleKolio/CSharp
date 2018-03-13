using System;
using System.Collections.Generic;

public class Engine
{
    public void Run()
    {
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            List<string> arguments = InputParser.SplitInput(input, " ");

            string command = arguments[0];

            switch (command)
            {
                default:
                    break;
            }
        }
    }
}