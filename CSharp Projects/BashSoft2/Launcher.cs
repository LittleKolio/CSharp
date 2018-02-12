namespace BashSoft2
{
    using IO;
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
            //string path = @"../../Resources";
            //IOManager.TraversingFileSystem(path);

            string path = @"../../Resources/data.txt";
            StudentsRepository.InitializeData(path);
            StudentsRepository.GetAllStudents("Unity");
        }
    }
}
