namespace Trash.CSharp_Advanced_Exam_25June2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Exam01_Regeh
    {
        public static void Main()
        {
            string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            int index = 0;
            foreach (Match match in matches)
            {
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    index += int.Parse(match.Groups[i].Value);
                    int correctIndex = index % input.Length;
                    Console.Write(input[correctIndex]);
                }
            }
            Console.WriteLine();
        }
    }
}
