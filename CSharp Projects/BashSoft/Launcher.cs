﻿namespace BashSoft
{
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
            //string input;
            //while ((input = Console.ReadLine()) != "end")
            //{
            //    OutputWriter.DisplayExeption(input);
            //}

            //string path = @"D:\Movies";
            //IOManager.TraverseFolder(path);

            //StudentsRepository.InitializeData();
            //StudentsRepository.ReadData();
            //StudentsRepository.GetStudentScores("Unity", "Ivan");

            CustomPath.ChangePath(@"C:\Windows");
            IOManager.TraverseFolder(20);
        }
    }
}
