using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Exercises
{
    class Exercises_01_Odd_Lines
    {
        const string filePath = "../../Files/someFileForStream.txt";

        static void Main()
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int lineNumber = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) { break; }

                    if (lineNumber % 2 != 0)
                    { Console.WriteLine($"Line {lineNumber}: {line}"); }

                    lineNumber++;
                }
            }
        }
    }
}
