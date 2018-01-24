namespace Simple
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileOperations
    {
        public static void Main()
        {
            string path = @"D:\Downloads\test.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("File exists");
            }

            string[] lines = File.ReadAllLines(path);

            string allText = File.ReadAllText(path);

        }

    }
}
