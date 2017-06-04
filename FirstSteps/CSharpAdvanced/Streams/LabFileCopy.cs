using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Streams
{
    class LabFileCopy
    {
        const string sourceImagePath 
            = "../../Files/240_F_73070034_kwp7lLXkOB2Mv0gMGy578A2DAcX4lA2L.jpg";
        const string newImagePath = "../../Files/result.jpg";
        static void Main()
        {
            using (FileStream reader = new FileStream(sourceImagePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(newImagePath, FileMode.Create))
                {
                    double fileLength = reader.Length;
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) { break; }

                        writer.Write(buffer, 0, readBytes);
                        Console.WriteLine("{0:P}", Math.Min(reader.Position / fileLength, 1));
                    }
                }
            }
        }
    }
}
