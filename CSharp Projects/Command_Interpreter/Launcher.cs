namespace Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Launcher
    {
        public static void Main()
        {
            string path = @"D:\Downloads";
            //string path = @"C:\Windows";
            IOManager.TraversingFileSystem(path);
        }
    }
}
