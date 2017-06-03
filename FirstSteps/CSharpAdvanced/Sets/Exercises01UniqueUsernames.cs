using System;
using System.Collections.Generic;

namespace CSharpAdvanced.Sets
{
    class Exercises01UniqueUsernames
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            HashSet<string> collection = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                collection.Add(name);
            }

            Console.WriteLine(string.Join("\n", collection));
        }
    }
}
