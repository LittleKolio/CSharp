namespace Trash.Lab05_Streams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lab01_Read_File
    {
        public static void Main()
        {
            string path = @"../../Lab05_Streams/Lab01_Read_File.cs";

            using (StreamReader stream = new StreamReader(path))
            {
                int count = 0;
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.Write($"Line {++count}: ");
                    Console.WriteLine(line);

                }
            }
        }
    }
}
