using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    class Lab_Memory_Stream
    {
        static void Main()
        {
            string text = "StreamReader. This reads text files. It is found in the System.IO namespace. It provides good performance and is easy to add to programs.";
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                while (true)
                {
                    int readByte = memoryStream.ReadByte();
                    if (readByte == -1) { break; }
                    Console.WriteLine(readByte);
                }
            }
        }
    }
}
