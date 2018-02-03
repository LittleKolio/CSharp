namespace Trash.Lab05_Streams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab03_Write_File_FileStream
    {
        public static void Main()
        {
            string file = @"../../Lab05_Streams/Lab03_Write_File_FileStream.cs";
            string path = @"../../Lab05_Streams/FileStream_Lab03.txt";

            FileStream writeStream = new FileStream(path, FileMode.Create);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(file);

            using (writeStream)
            {
                writeStream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
