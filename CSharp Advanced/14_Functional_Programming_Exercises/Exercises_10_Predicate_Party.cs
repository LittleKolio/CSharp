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
            List<string> names = Console.ReadLine()
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

                if (command[0] == "Remove") { RemovePerson(ref names, pred); }
                if (command[0] == "Double") { DoublePerson(ref names, pred); }
            }

            PrintPartyMember(names);
        }

        private static void RemovePerson(ref List<string> names, Predicate<string> name)
        {
            List<string> temp = new List<string>();
            temp.CopyTo
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

        private static void PrintPartyMember(List<string> names)
        {
            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) +
                    " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
