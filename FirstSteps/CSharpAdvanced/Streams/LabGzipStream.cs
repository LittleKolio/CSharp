using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced.Streams
{
    class LabGzipStream
    {
        static void Main()
        {
            Compress(
                "../../Files/textForZip.txt", 
                "../../Files/zipped.gz");

            Decompress(
                "../../Files/zipped.gz", 
                "../../Files/resultFromZip.txt");
        }

        static void Decompress(string inputFile, string outputFile)
        {
            using (FileStream inputStream = new FileStream(
                inputFile, FileMode.Open))
            {
                using (GZipStream compressionStream = new GZipStream(
                    inputStream, CompressionMode.Decompress, false))
                {
                    using (FileStream outputStream = new FileStream(
                        outputFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = compressionStream.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)  { break; }
                            outputStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        static void Compress(string inputFile, string outputFile)
        {
            using (FileStream inputStream = new FileStream(
                inputFile, FileMode.Open))
            {
                using (FileStream outputStream = new FileStream(
                    outputFile, FileMode.Create))
                {
                    using (GZipStream compressionStream = new GZipStream(
                        outputStream, CompressionMode.Compress, false))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = inputStream.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0) { break; }
                            compressionStream.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
