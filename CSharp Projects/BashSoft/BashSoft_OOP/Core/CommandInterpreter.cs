namespace BashSoft_OOP.Core
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IStudentsRepository studentsRepository;

        public CommandInterpreter(
            IStudentsRepository studentsRepository
            )
        {
            this.studentsRepository = studentsRepository;
        }

        public IExecutable Interpreter(string[] arguments)
        {
            string command = CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(arguments[0])
                + "Command";

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetType(command);

            return null;
        }

        //public void Interpreter(string cmd, string[] tokens)
        //{
        //    switch (cmd)
        //    {
        //        //mkdir directoryName
        //        //create a directory in the current directory
        //        case "mkdir":
        //            {
        //                if (CheckNumberOfParameters(1, tokens.Length))
        //                {
        //                    string directoryName = tokens[0];
        //                    FilesystemManager.CreateDirectory(directoryName);
        //                }
        //            } break;

        //        //ls
        //        //traverse the current directory to the given depth
        //        case "ls":
        //            {
        //                if (CheckNumberOfParameters(1, tokens.Length))
        //                {
        //                    int depth;
        //                    if (!int.TryParse(tokens[0], out depth))
        //                    {
        //                        ConsoleWriter.WriteException(
        //                            string.Format(ExceptionMessages.params_InvalidParameter, tokens[0]));
        //                        return;
        //                    }
        //                    this.ioManager.TraversingDirectory(depth);
        //                }
        //            } break;

        //        //cmp absolutePath1 absolutePath2
        //        //comparing two files by given two absolute paths
        //        case "cmp":
        //            {
        //                if (CheckNumberOfParameters(2, tokens.Length))
        //                {
        //                    string filePath1 = tokens[0];
        //                    string filePath2 = tokens[1];
        //                    this.ioManager.CompareTwoFiles(filePath1, filePath2);
        //                }
        //            } break;

        //        //changeDirRel relativePath
        //        //change the current directory by a relative path
        //        case "changeDirRel":
        //            {
        //                if (CheckNumberOfParameters(1, tokens.Length))
        //                {
        //                    string relativePath = tokens[0];
        //                    FilesystemManager.ChangeDirectoryByRelativePath(relativePath);
        //                }
        //            } break;

        //        //changeDirAbs absolutePath
        //        //change the current directory by an absolute path
        //        case "changeDirAbs":
        //            {
        //                if (CheckNumberOfParameters(1, tokens.Length))
        //                {
        //                    string absolutPath = tokens[0];
        //                    FilesystemManager.ChangeDirectory(absolutPath);
        //                }
        //            } break;

        //        //open fileName
        //        //opens a file
        //        case "open":
        //            {
        //                if (CheckNumberOfParameters(1, tokens.Length))
        //                {
        //                    string fileName = tokens[0];
        //                    this.ioManager.OpenFileWithDefaultProgram(fileName);
        //                }
        //            } break;

        //        //readDb dataBaseFileName
        //        //read students database by a given name of the database file
        //        //which is placed in the current folder
        //        case "readDb":
        //            {
        //                if (CheckNumberOfParameters(1, tokens.Length))
        //                {
        //                    string fileName = tokens[0];
        //                    this.studentsRepository.ReadDataFromFile(fileName);
        //                }
        //            } break;

        //        //show courseName (studentName)
        //        //search database by a given course name or course and student name
        //        //print the result
        //        case "show":
        //            {
        //                if (tokens.Length == 1)
        //                {
        //                    string courseName = tokens[0];
        //                    Dictionary<string, List<int>> course 
        //                        = this.studentsRepository.GetCourse(courseName);
        //                    foreach (KeyValuePair<string, List<int>> student in course)
        //                    {
        //                        ConsoleWriter.PrintStudent(student);
        //                    }
        //                }
        //                else if (tokens.Length == 2)
        //                {
        //                    string courseName = tokens[0];
        //                    string studentName = tokens[1];
        //                    List<int> scoresList 
        //                        = this.studentsRepository.GetStudent(courseName, studentName);
        //                    ConsoleWriter.PrintStudent(new KeyValuePair<string, List<int>>(
        //                        studentName, scoresList));
        //                }
        //                else
        //                {
        //                    ConsoleWriter.WriteException(
        //                        string.Format(ExceptionMessages.params_InvalidNumber, tokens.Length));
        //                }
        //            } break;

        //        //filter courseName poor/average/excellent 2/10/42/all
        //        //filter students from а given course by a given filter option
        //        //and add quantity of students to take
        //        case "filter":
        //            {
        //                if (CheckNumberOfParameters(3, tokens.Length))
        //                {
        //                    string courseName = tokens[0];
        //                    string filter = tokens[1];
        //                    string take = tokens[2];

        //                    Dictionary<string, List<int>> course = this.studentsRepository.GetCourse(courseName);

        //                    Dictionary<string, List<int>> filteredStudents
        //                        = this.repositoryFilter.FilterInterpreter(course, filter, take);

        //                    if (filteredStudents.Count > 0)
        //                    {
        //                        foreach (KeyValuePair<string, List<int>> student in filteredStudents)
        //                        {
        //                            ConsoleWriter.PrintStudent(student);
        //                        }
        //                    }
        //                }
        //            } break;

        //        //order courseName ascending/descending 3/26/52/all
        //        //order student from a given course by ascending or descending order
        //        //and then take some of them or all that match it
        //        case "order":
        //            {
        //                if (CheckNumberOfParameters(3, tokens.Length))
        //                {
        //                    string courseName = tokens[0];
        //                    string order = tokens[1];
        //                    string take = tokens[2];

        //                    Dictionary<string, List<int>> course = this.studentsRepository.GetCourse(courseName);

        //                    Dictionary<string, List<int>> sortedStudents 
        //                        = this.repositorySorter.SortInterpreter(course, order, take);

        //                    if (sortedStudents.Count > 0)
        //                    {
        //                        foreach (KeyValuePair<string, List<int>> student in sortedStudents)
        //                        {
        //                            ConsoleWriter.PrintStudent(student);
        //                        }
        //                    }
        //                }
        //            } break;

        //        //download pathOfFile
        //        //download a file
        //        case "download": break;

        //        //downloadAsynch pathOfFile
        //        //download file asynchronously
        //        case "downloadAsynch": break;

        //        //help
        //        case "help": break;

        //        default:
        //            break;
        //    }
        //}

        //private bool CheckNumberOfParameters(int num, int tokens)
        //{
        //    if (tokens != num)
        //    {
        //        ConsoleWriter.WriteException(
        //            string.Format(ExceptionMessages.params_InvalidNumber, num));
        //        return false;
        //    }
        //    return true;
        //}
    }
}
