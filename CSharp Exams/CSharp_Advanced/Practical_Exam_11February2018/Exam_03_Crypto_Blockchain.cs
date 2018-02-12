namespace Practical_Exam_11February2018
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Exam_03_Crypto_Blockchain
    {
        public static void Main()
        {
            string pattern = @"((?<between>\{)|\[)\D*(?<digit>\d+)\D*(?(between)\}|\])";
            int magicNum = 3;
            StringBuilder str = new StringBuilder();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                str.Append(Console.ReadLine());
            }

            MatchCollection matches = Regex.Matches(str.ToString(),pattern);
            foreach (Match match in matches)
            {
                string digit = match.Groups["digit"].Value;
                int mLength = match.Length;
                int length = match.Groups["digit"].Length;

                if (length % magicNum == 0)
                {
                    for (int i = 0; i < length; i += magicNum)
                    {
                        int num = int.Parse(digit.Substring(i, magicNum)) - mLength;
                        Console.Write((char)num);
                    }
                }
            }
        }
    }
}
