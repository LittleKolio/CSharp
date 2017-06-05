using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Streams
{
    class Exercises04CopyBinaryFile
    {
        const string sourceImagePath = "../../Files/ostrich.jpg";
        const string newImagePath = "../../Files/ostrichCopy.jpg";
        static void Main()
        {
            using (FileStream reader = new FileStream(
                sourceImagePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(
                    newImagePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) { break; }

                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
