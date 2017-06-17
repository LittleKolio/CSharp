using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_10_Predicate_Party
    {
        static void Main()
        {
            List<string> listNames = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Party!") { break; }

                Predicate<string> pred = CorectName(command[1], command[2]);

                List<string> processingNames = listNames.Where(name => pred(name)).ToList();

                WathToDo(ref listNames, processingNames, command[0]);
            }

            PrintPartyMember(listNames);
        }

        private static void WathToDo(ref List<string> listNames, List<string> processingNames, string command)
        {
            switch (command)
            {
                case "Double":
                    listNames = listNames.Concat(processingNames).ToList(); break;
                case "Remove":
                    listNames = listNames.Except(processingNames).ToList(); break;
                default: break;
            }
        }

        private static Predicate<string> CorectName(string criteria, string str)
        {
            switch (criteria)
            {
                case "StartsWith": return name => name.Substring(0, str.Length) == str;
                case "EndsWith": return name => name.Substring(name.Length - str.Length) == str;
                case "Length": return name => name.Length == int.Parse(str);
                default: return null;
            }
        }

        private static void PrintPartyMember(List<string> listNames)
        {
            if (listNames.Count > 0)
            {
                Console.WriteLine(string.Join(", ", listNames) +
                    " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
