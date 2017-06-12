using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sets_And_Dictionaries_Exercises
{
    class Exercises_07_Fix_Emails
    {
        static void Main()
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            Regex regex = new Regex(@"\.(us|uk)$");
            string name = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "stop") { break; }

                if (!input.Contains('@'))
                {
                    emails.Add(input, string.Empty);
                    name = input;
                }
                else
                {
                    //string domain = input
                    //    .Substring(input.Length - 2)
                    //    .ToLower();

                    //if (new[] { "us", "uk" }.Contains(domain))
                    //{
                    //    emails.Remove(name);
                    //}

                    if (regex.Match(input).Success)
                    {
                        emails.Remove(name);
                    }
                    else
                    {
                        emails[name] = input;
                    }
                }
            }

            foreach (var item in emails)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
