using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {

        }

    }

    private static List<string> SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}