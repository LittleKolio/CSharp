using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpAdvanced.RegularExpression
{
    class Exercises10UseYourChainsBuddy
    {
        private const string tagPattern = @"<p>(.*?)<\/p>";
        private const string spacePattern = "[^a-z0-9]+";
        //private const string symbolPattern = "([a-m])";

        static void Main()
        {
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, tagPattern);

            StringBuilder sb = new StringBuilder();
            foreach (Match match in matches)
            {
                //Console.WriteLine(match.Groups[1].Value);

                string tagText = Regex.Replace(match.Groups[1].Value, spacePattern, " ");
                //Console.WriteLine(tagText);

                //string replaceSymbols = Regex.Replace(tagText, symbolPattern,
                //    m => new string((char)(m.Groups[1].Value[0] + 13), 1));
                //Console.WriteLine(replaceSymbols);

                foreach (char c in tagText)
                {
                    if (c >= 'a' && c <= 'm') { sb.Append((char)(c + 13)); }
                    else if (c >= 'n' && c <= 'z') { sb.Append((char)(c - 13)); }
                    else { sb.Append(c); }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
