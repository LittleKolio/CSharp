namespace Exercises_03_Longest_Subsequence
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
            List<int> nums = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            int index = 0;
            int length = 1;

            int count = 1;

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count > length)
                {
                    index = i - count + 1;
                    length = count;
                }
            }

            for (int i = index; i < index + length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
