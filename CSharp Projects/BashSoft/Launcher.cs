namespace BashSoft
{
    using Core;
    using IO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Launcher
    {
        static void Main()
        {
            //string path = @"D:\Movies";
            //IOManager.TraverseFolder(path);

            //StudentsRepository.InitializeData();
            //StudentsRepository.ReadData();
            //StudentsRepository.GetStudentScores("Unity", "Ivan");

            //CustomPath.ChangePath(@"C:\Windows");
            //IOManager.TraverseFolder(20);

            Engine engine = new Engine();
            engine.Run();
        }
    }
}
