using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Exercises
{
    class Exercises_05_Slicing_File
    {
        const string sourceVideo = "American Gods S01E05 1080p WEBRip 6CH HEVC x265-RMTeam";
        const string path = "../../Files/";
        const string format = ".mkv";
        static void Main()
        {
            int parts = int.Parse(Console.ReadLine());
            List<string> namesAndPaths = new List<string>();

            using (FileStream reader = new FileStream(
                path + sourceVideo + format, 
                FileMode.Open, 
                FileAccess.Read))
            {
                byte[] buffer = new byte[reader.Length / parts];
                int bytes, count = 0;

                while ((bytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string name = path + "Part-" + count + format;
                    namesAndPaths.Add(name);
                    using (FileStream writer = new FileStream(
                        name, 
                        FileMode.Create, 
                        FileAccess.Write))
                    {
                        writer.Write(buffer, 0, bytes);
                    }

                    count++;
                }
            }

            using (FileStream writer = new FileStream(
                path + "Result" + format,
                FileMode.Create,
                FileAccess.Write))
            {
                byte[] buffer = new byte[4096];

                foreach (var part in namesAndPaths)
                {
                    using (FileStream reader = new FileStream(
                        part,
                        FileMode.Open,
                        FileAccess.Read))
                    {
                        int bytes;
                        while ((bytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            writer.Write(buffer, 0, bytes);
                        }
                    }
                }
            }
        }
    }
}
