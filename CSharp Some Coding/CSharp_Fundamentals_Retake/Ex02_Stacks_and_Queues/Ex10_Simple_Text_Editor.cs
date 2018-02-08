namespace Trash.Ex02_Stacks_and_Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex10_Simple_Text_Editor
    {
        private static StringBuilder sb;
        private static Stack<string> stack;

        public static void Main()
        {
            sb = new StringBuilder();
            stack = new Stack<string>();

            int num = int.Parse(Console.ReadLine());

            //string input;
            //while (!string.IsNullOrEmpty(
            //    input = Console.ReadLine()))

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();

                Operations(input);
            }
        }

        private static void Operations(string input)
        {
            string[] tokens = SplitInput(input, " ");

            switch (tokens[0])
            {
                case "1":
                    {
                        sb.Append(tokens[1]);
                        stack.Push("2 " + tokens[1].Length.ToString());
                    }
                    break;

                case "2":
                    {
                        int length = int.Parse(tokens[1]);
                        int start = sb.Length - length;

                        string strRecover = sb.ToString().Substring(start);
                        sb.Remove(sb.Length - length, length);

                        stack.Push("1 " + strRecover);
                    }
                    break;

                case "3":
                    {
                        int index = int.Parse(tokens[1]) - 1;
                        Console.WriteLine(sb[index]);
                    }
                    break;

                case "4":
                    {
                        Operations(stack.Pop());
                        stack.Pop();
                    }
                    break;

                default:
                    break;
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input
                .Split(delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }
    }
}
