namespace Trash.Ex02_Stacks_and_Queues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Ex07_Balanced_Parentheses
    {
        public static void Main()
        {
            string openPar = "({[";
            string closePar = ")}]";

            string par = Console.ReadLine();

            string success = "YES";

            if (par.Length % 2 == 0)
            {
                Stack<char> stack = new Stack<char>();
                Queue<char> queue = new Queue<char>(par.ToCharArray());
                while (queue.Count > par.Length / 2)
                {
                    stack.Push(queue.Dequeue());
                }

                while (stack.Count > 0)
                {
                    //Console.WriteLine(stack.Peek());
                    //Console.WriteLine(queue.Peek());

                    int indexOpen = openPar.IndexOf(stack.Pop());
                    int indexClose = closePar.IndexOf(queue.Dequeue());

                    if (indexOpen != indexClose)
                    {
                        success = "NO";
                        break;
                    }
                }
            }
            else
            {
                success = "NO";
            }

            Console.WriteLine(success);
        }
    }
}
