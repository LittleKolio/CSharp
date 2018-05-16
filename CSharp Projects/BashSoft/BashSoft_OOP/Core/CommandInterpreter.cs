namespace BashSoft_OOP.Core
{
    using Interfaces;
    using StaticData;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        private Type[] commandTypes;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.commandTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes();
        }

        public IExecutable Interpreter(string[] arguments)
        {
            string commandInput = this.InputCommandformat(arguments[0]);

            Type commandType = this.commandTypes
                .FirstOrDefault(t => t.Name == commandInput);

            if (commandType == null)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.command_DoseNotExist, arguments[0]));
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.command_IsNotExecutable, arguments[0]));
            }

            ParameterInfo[] commandTypeParameters = commandType
                .GetConstructors()
                .FirstOrDefault()
                .GetParameters();

            object[] parameters = new object[commandTypeParameters.Length];
            parameters[0] = arguments.Skip(1).ToArray();

            for (int i = 1; i < commandTypeParameters.Length; i++)
            {
                Type parameterType = commandTypeParameters[i].ParameterType;
                parameters[i] = this.serviceProvider.GetService(parameterType);
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, parameters);

            return command;
        }

        private string InputCommandformat(string input)
        {
            return CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(input)
                + "Command";
        }

        //public void Interpreter(string cmd, string[] tokens)
        //{
        //    switch (cmd)
        //    {

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
    }
}
