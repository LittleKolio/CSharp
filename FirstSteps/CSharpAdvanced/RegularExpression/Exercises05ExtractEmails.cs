using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Exercises05ExtractEmails
    {
        private const string pattern =
            @"\b" + 
            "(?<![-._])" + 
            @"(?<user>[^\W_]+[-._]*[^\W_]+)" + 
            "(?![-._])" + 
            "@" + 
            "(?<![-._])" + 
            @"(?<host>([a-zA-Z]+-?[a-zA-Z]+\.)+[a-zA-Z]+)" + 
            @"\b";

        static void Main()
        {
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
