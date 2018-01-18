namespace Exercises_05_Count_of_Occurrences
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
            List<string> nums = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < nums.Count; i++)
            {
                string num = nums[i];

                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, 0);
                }
                dic[num]++;
            }

            foreach (KeyValuePair<string, int> item in dic.OrderBy(a => a.Key))
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }

        }
    }
}
