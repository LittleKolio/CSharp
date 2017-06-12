using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    class Lab_Buffered_Writer
    {
        static void Main()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            using (FileStream fileStream = new FileStream(
                "../../Files/bufferWriter.txt", FileMode.Create))
            {
                for (int i = 0; i < 1000000; i++)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(i.ToString("X"));
                    fileStream.Read(buffer, 0, buffer.Length);
                    //fileStream.Flush();
                }
            }

            watch.Stop();
            Console.WriteLine($"Done: {watch.Elapsed}");
        }
    }
}
