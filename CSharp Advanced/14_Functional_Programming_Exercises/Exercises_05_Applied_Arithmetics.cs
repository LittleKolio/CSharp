namespace Functional_Programming_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_05_Applied_Arithmetics
    {
        public static void Main()
        {
            int[] list = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", list));
                    break;
                }

                Func<int, int> func = SwitchFunc(command);
                ApplyingArithmetics(list, func);
            }
        }

        public static void ApplyingArithmetics(int[] list, Func<int, int> func)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = func(list[i]);
            }
        }

        public static Func<int, int> SwitchFunc(string command)
        {
            switch (command)
            {
                case "add": return num => num + 1;
                case "multiply": return num => num * 2;
                case "subtract": return num => num - 1;
                default: return null;
            }
        }
    }
}
