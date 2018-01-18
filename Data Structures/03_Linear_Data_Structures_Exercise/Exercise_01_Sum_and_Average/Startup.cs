namespace Exercises_01_Sum_and_Average
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
            string input = Console.ReadLine();

            List<int> list = new List<int>();

            string result = "Sum={0}; Average={1:F2}";
            int sum = 0;
            double avr = 0.0;

            if (!string.IsNullOrEmpty(input))
            {
                string[] tokens = input.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                int temp;
                foreach (string item in tokens)
                {
                    if (int.TryParse(item, out temp))
                    {
                        list.Add(temp);
                    }
                    else
                    {
                        list.Add(default(int));
                    }
                }

                sum = list.Sum();
                avr = list.Average();
            }
            //else
            //{
            //    throw new ArgumentNullException(
            //        "Nothing is passed to the console");
            //}

            Console.WriteLine(result, sum, avr);
        }
    }
}
