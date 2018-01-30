namespace Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Launcher
    {
        public static void Main()
        {
            //string path = @"D:\Downloads";
            string path = Directory.GetCurrentDirectory();
            //string path = @"C:\Windows";
            //IOManager.TraversingFileSystem(path);

            Console.WriteLine(path);
            Console.ReadKey();
        }
    }
}
