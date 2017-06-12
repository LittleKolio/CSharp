using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Lab
{
    class Lab_02_SoftUni_Party
    {
        static void Main()
        {
            SortedSet<string> list = new SortedSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY") { break; }
                list.Add(input);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") { break; }
                list.Remove(input);
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join("\n", list));
        }
    }
}
