﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    class Lab_Stream_Reader
    {
        static void Main()
        {
            using (StreamReader reader = new StreamReader(
                "../../Files/someFileForStream.txt"))
            {
                int lineNumber = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) { break; }

                    lineNumber++;
                    Console.WriteLine($"Line {lineNumber}: {line}");
                }
            }
        }
    }
}
