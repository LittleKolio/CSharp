using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample_Exam_1_June2016
{
    class Exam_02_Array_Modifier
    {
        public static void Main()
        {
            List<long> nums = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList();
            string coms = Console.ReadLine();
            while (coms != "end")
            {
                string[] com = coms.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (com[0])
                {
                    case "swap":
                        {
                            int index1 = int.Parse(com[1]);
                            int index2 = int.Parse(com[2]);
                            long old = nums[index1];
                            nums[index1] = nums[index2];
                            nums[index2] = old;
                        }
                        break;
                    case "multiply":
                        {
                            int index1 = int.Parse(com[1]);
                            int index2 = int.Parse(com[2]);
                            nums[index1] *= nums[index2];
                        }
                        break;
                    case "decrease":
                        {
                            nums = nums.Select(x => x -= 1).ToList();
                        }
                        break;
                }
                coms = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
