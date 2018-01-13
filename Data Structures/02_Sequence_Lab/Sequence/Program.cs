using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> que = new Queue<int>();
            string[] nums = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

            int startNum = int.Parse(nums[0]);
            int endNum = int.Parse(nums[1]);

            que.Enqueue(startNum);
            int temp = startNum;

            while (temp != endNum)
            {
                temp = que.Dequeue();
                que.Enqueue(temp + 1);
                que.Enqueue(temp * 2);

                Console.WriteLine(temp);
            }
        }
    }
}
