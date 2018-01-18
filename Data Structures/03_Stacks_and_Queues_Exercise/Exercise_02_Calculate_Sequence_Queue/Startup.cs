namespace Exercise_02_Calculate_Sequence_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Queue<int> que = new Queue<int>();

            int num = int.Parse(Console.ReadLine());

            que.Enqueue(num);

            for (int i = 0; i < 50; i++)
            {
                int temp = que.Dequeue();
                que.Enqueue(temp + 1);
                que.Enqueue(temp * 2 + 1);
                que.Enqueue(temp + 2);

                string str = string.Empty;

                if (i + 1 != 50)
                {
                    str = ", ";
                }

                Console.Write(temp + str);
            }

            Console.WriteLine();
        }
    }
}
