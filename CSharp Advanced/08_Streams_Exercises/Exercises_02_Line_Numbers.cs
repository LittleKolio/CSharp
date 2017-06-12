using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Exercises
{
    class Exercises_02_Line_Numbers
    {
        const string sourceFilePath = "../../Files/someFileForStream.txt";
        const string resultFilePath = "../../Files/resultForStream.txt";

        static void Main()
        {
            using (StreamReader reader = new StreamReader(sourceFilePath))
            {
                using (StreamWriter writer = new StreamWriter(resultFilePath))
                {
                    int lineNumber = 0;
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) { break; }

                        writer.WriteLine($"Line {lineNumber} : " + line);
                        lineNumber++;
                    }
                }
            }
        }
    }
}
