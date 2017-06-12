using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sets_And_Dictionaries_Lab
{
    class Lab_01_Parking_Lot
    {
        static void Main()
        {
            //HashSet<string> parking = new HashSet<string>();
            SortedSet<string> parking = new SortedSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") { break; }

                string[] str = Regex.Split(input, @",\s", 
                    RegexOptions.IgnorePatternWhitespace);

                if (str[0] == "IN")
                {
                    parking.Add(str[1]);
                }
                else
                {
                    if (parking.Contains(str[1]))
                    {
                        parking.Remove(str[1]);
                    }
                }
            }

            if (parking.Count != 0)
            {
                Console.WriteLine(string.Join("\n", parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
