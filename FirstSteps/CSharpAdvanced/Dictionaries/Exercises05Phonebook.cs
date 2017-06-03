using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Dictionaries
{
    class Exercises05Phonebook
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while (true)
            {
                string[] input = Console.ReadLine()
                   .Split(new[] { '-' },
                       StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "search") { break; }

                if (!phonebook.ContainsKey(input[0]))
                {
                    phonebook.Add(input[0], input[1]);
                }
                else
                {
                    phonebook[input[0]] = input[1];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop") { break; }

                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
        }
    }
}
