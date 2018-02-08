namespace Trash.Lab05_Streams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab02_Write_to_File
    {
        public static void Main()
        {
            string pathRead = @"../../Lab05_Streams/Lab02_Write_to_File.cs";
            string pathWrite = @"../../Lab05_Streams/Rev_Lab02.txt";

            using (StreamReader readStream = new StreamReader(pathRead))
            {
                using (StreamWriter writeStream = new StreamWriter(pathWrite))
                {
                    string line;
                    while ((line = readStream.ReadLine()) != null)
                    {
                        writeStream.WriteLine(line.Reverse().ToArray());
                    }
                }
            }
        }
    }
}
