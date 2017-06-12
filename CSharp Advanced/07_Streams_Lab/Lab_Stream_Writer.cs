using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    /// <summary>
    /// StreamReader
    /// This reads text files.
    /// It is found in the System.IO namespace.
    /// It provides good performance and is easy to add to programs.
    /// 
    /// Using
    /// StreamReader is often used with the using-statement.
    /// This construct helps dispose of the system resources.
    /// We often place a loop inside using()
    /// </summary>
    class Lab_Stream_Writer
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
