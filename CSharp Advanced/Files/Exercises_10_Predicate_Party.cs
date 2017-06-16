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
            string[] names = Console.ReadLine()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Party!") { break; }



                Predicate<string> name = CorectName(command[1], command[2]);
                Action<string[], string> action = ActionSwitcher(command[0]);
            }

            PrintPartyMember(names);
        }

        private static Action<string[], string> ActionSwitcher(string action)
        {
            switch (action)
            {
                case "Remove": return (list, name) => list.Remove(name);
                case "Double": return (list, name) => list.a(name);
                default: return null;
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
