using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.String
{
    class Lab03ParseTags
    {
        static void Main()
        {
            string openingTag = "<upcase>";
            string closingTag = "</upcase>";

            string text = Console.ReadLine();
            //Console.WriteLine(text.Length);

            int count = 0;
            while (true)
            {
                int indexStart = text.IndexOf(openingTag, count);
                //Console.WriteLine(text.Substring(indexStart, openingTag.Length));

                int indexEnd = text.IndexOf(closingTag, indexStart + openingTag.Length);
                //Console.WriteLine(text.Substring(indexEnd, closingTag.Length));

                if (indexStart == -1 || indexEnd == -1) { break; }

                /*
                string str = text
                    .Substring(
                        indexStart + openingTag.Length, 
                        indexEnd - (indexStart + openingTag.Length));

                text = text
                    .Remove(
                        indexStart,
                        indexEnd + closingTag.Length - indexStart)
                    .Insert(indexStart, str.ToUpper());
                */

                string subString = text
                    .Substring(
                        indexStart,
                        indexEnd + closingTag.Length - indexStart);

                string formatSubString = subString
                    .Replace(openingTag, string.Empty)
                    .Replace(closingTag, string.Empty)
                    .ToUpper();

                text = text.Replace(subString, formatSubString);

                count = indexEnd - openingTag.Length;
            }

            Console.WriteLine(text);
        }
    }
}
