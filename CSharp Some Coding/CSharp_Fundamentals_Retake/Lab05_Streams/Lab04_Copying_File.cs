namespace Trash.Lab05_Streams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab04_Copying_File
    {
        public static void Main()
        {
            string file = @"../../Lab05_Streams/Green_Sea_Turtle.jpg";
            string path = @"../../Lab05_Streams/CopyFile_Lab04.jpg";

            FileStream readStream = new FileStream(file, FileMode.Open);
            FileStream writeStream = new FileStream(path, FileMode.Create);

            using (readStream)
            {
                using (writeStream)
                {
                    byte[] buffer = new byte[4096];
                    while (true)
                    {
                        int read = readStream.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            break;
                        }

                        writeStream.Write(buffer, 0, read);
                    }
                }
            }
        }
    }
}
