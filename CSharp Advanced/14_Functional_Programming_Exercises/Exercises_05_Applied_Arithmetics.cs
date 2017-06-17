using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Programming_Exercises
{
    class Exercises_05_Applied_Arithmetics
    {
        public static void Main()
        {
            Action<int> print = num => Console.WriteLine(num);

            int[] list = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", list));
                    break;
                }
                else
                {
                    Func<int, int> func = SwitchFunc(command);
                    ApplyingArithmetics(ref list, func);
                }
            }
        }

        public static void ApplyingArithmetics(ref int[] list, Func<int, int> func)
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
                //case "add": return num => num++; ... :-/ not woking?
                case "add": return num => num += 1;
                case "multiply": return num => num *= 2;
                case "subtract": return num => num -= 1;
                default: return null;
            }
        }
    }
}
