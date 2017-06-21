using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Sample_Exam_1_From_19June2016
{
    class Exam_03_Cubics_Messages
    {
        public const string pattern = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]*)$";
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Over!") { break; }

                int length = int.Parse(Console.ReadLine());

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string indexes = match.Groups[1].Value;
                    string message = match.Groups[2].Value;
                    if (match.Groups[3].Value != "")
                    {
                        indexes += Regex.Replace(match.Groups[3].Value, @"\D*", string.Empty);
                    }

                    if (message.Length == length)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var item in indexes)
                        {
                            int i = int.Parse(item.ToString());
                            if (0 <= i && i < length)
                            {
                                sb.Append(message[i]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }

                        Console.WriteLine($"{message} == {sb}");
                    }
                }
            }
        }
    }
}
