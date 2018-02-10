namespace Trash.CSharp_Advanced_Exam_3September2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Exam_04_Treasure_Map
    {
        public static void Main()
        {
            string pattern = @"((?<between>#)|!)[^!#]*?\b(?<str>\w{4})\b[^!#]*?(?<!\d)(?<add>\d{3})-(?<pass>\d{6}|\d{4})\W*?[^!#]*?(?(between)!|#)";

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                MatchCollection matchCollection = Regex.Matches(Console.ReadLine(), pattern);

                Match match = matchCollection[matchCollection.Count / 2];

                string address = match.Groups["add"].Value;
                string street = match.Groups["str"].Value;
                string password = match.Groups["pass"].Value;

                Console.WriteLine($"Go to str. {street} {address}. Secret pass: {password}.");
            }
        }
    }
}
