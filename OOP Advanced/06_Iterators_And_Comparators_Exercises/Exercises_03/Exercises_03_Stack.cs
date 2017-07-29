namespace Iterators_And_Comparators_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_03_Stack
    {
        static void Main()
        {
            CustomStack<string> stack = new CustomStack<string>();

            string commands;
            while (!(commands = Console.ReadLine()).Equals("END"))
            {
                string[] tokens = commands.Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Push":
                        stack.Push(tokens.Skip(1).ToArray());
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }

            Print(stack);
            Print(stack);
        }

        private static void Print(CustomStack<string> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
