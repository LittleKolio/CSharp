using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practical_Exam_25June2017
{
    /// <summary>
    /// You need to read a line from the console and match everything that is in square brackets.
    /// You must have no whitespaces inside the match.
    /// Inside the match you must have [(ASCII Symbols)<(Some digits)REGEH(Some digits)>(ASCII Symbols)]
    /// If you have nested brackets you need to match the inner most.
    /// After you find a match you must extract the numbers between the < > brackets.
    /// Then use the first number like index to get character from input.
    /// Second index is the sum of first tow numbres, third index is the sum of first tow numbres and every index is the sum of all previous numbers.
    /// . When the index is larger than the string length start from the beginning of the string.
    /// </summary>
    /// <output>
    /// You must print on the console a single line with characters, that you find in the string.
    /// </output>
    /// <remarks>
    /// The line may contain any character.
    /// Line length will be 1 < n < 1000000.
    /// Time limit: 0.3 sec. Memory limit: 16 MB.
    /// </remarks>
    class Exam_01_Regeh
    {
        static void Main()
        {
            //string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";
            //"\.+?" - Lazy repetition -> "\S+?"
            string pattern = @"\[\S+?<(\d+)REGEH(\d+)>\S+?\]";
            Regex regex = new Regex(pattern);

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
