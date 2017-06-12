using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_String_Processing_Lab
{
    class Lab_02_Parse_URLs
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                string[] inputURL = input.Split(new[] { "://" },
                    StringSplitOptions.RemoveEmptyEntries);
                int index;
                if (inputURL.Length != 2 || 
                    (index = inputURL[1].IndexOf("/")) == -1)
                {
                    Console.WriteLine("Invalid URL");
                }
                else
                {
                    string protocol = inputURL[0];
                    string server = inputURL[1].Substring(0, index);
                    string resources = inputURL[1].Substring(index + 1);

                    Console.WriteLine($"Protocol = {protocol}");
                    Console.WriteLine($"Server = {server}");
                    Console.WriteLine($"Resources = {resources}");
                }
            }
        }
    }
}
