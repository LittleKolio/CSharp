using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        Gandalf gandalf = new Gandalf();

        string[] input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(s => char.ToUpper(s[0]) + s.Substring(1).ToLower())
            .ToArray();

        for (int i = 0; i < input.Length; i++)
        {
            gandalf.AddFood(
                FactoryFood.GetFood(input[i]));
        }

        Console.WriteLine(gandalf);
    }
}