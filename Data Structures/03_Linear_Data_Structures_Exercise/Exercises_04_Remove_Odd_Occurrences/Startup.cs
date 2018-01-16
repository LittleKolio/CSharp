namespace Exercises_04_Remove_Odd_Occurrences
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

            for (int i = 0; i < nums.Count; i++)
            {
                int num = nums[i];
                int count = 1;

                for (int j = 0; j < nums.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    if (num == nums[j])
                    {
                        count++;
                    }
                }

                if (count % 2 != 0)
                {
                    nums.RemoveAll(n => n == num);
                    i--;
                }
            }

            foreach (int n in nums)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }
    }
}
