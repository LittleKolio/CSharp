using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Streams
{
    class LabStreamWriter
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(
                "../../Streams/LabStreamWriter.cs"))
            {
                using (StreamWriter writer = new StreamWriter(
                    "../../Files/someFileForStreamWriter.txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null) { break; }

                        for (int i = line.Length - 1 ; i >= 0; i--)
                        {
                            writer.Write(line[i]);
                        }
                        writer.WriteLine();
                    }
                }
            }
        }
    }
}
