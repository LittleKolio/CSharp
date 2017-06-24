using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Exam_2_From_22August2016
{
    /// <summary>
    /// You will be given several input lines of random, upper case and lower case, English alphabet letters.
    /// The input ends when you receive the command "---NMS SEND---".
    /// You need to break the whole message into words.
    /// A word in this case is an increasing sequence of letters.
    /// Equal letters do NOT break the subsequence.
    /// The comparison is case-insensitive.
    /// After it you will receive a specified delimiter.
    /// </summary>
    /// <remarks>
    /// The delimiter can be a line of random ASCII characters with random length.
    /// The maximum lines of input you can receive is 1000.
    /// Allowed time/memory: 100ms/16MB
    /// </remarks>
    /// <output>
    /// print all the words you've found, separated by the given delimiter.
    /// </output>
    class Exam_03_NMS
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            string input;
            while ((input = Console.ReadLine()) != "---NMS SEND---")
            {
                sb.Append(input);
            }
            string delimiter = Console.ReadLine();
            string result = FormatInput(sb, delimiter);
            Console.WriteLine(result);
        }

        private static string FormatInput(StringBuilder input, string delimiter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (char.ToLower(input[i]) < char.ToLower(input[i - 1]))
                {
                    sb.Append(delimiter);
                }
                sb.Append(input[i]);
            }
            return sb.ToString();
        }
    }
}
