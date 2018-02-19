namespace BashSoft2.Engine
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CommandInterpreter
    {
        public static void InterpredCommand(string cmd, string[] tokens)
        {
            switch (cmd)
            {
                //mkdir directoryName
                //create a directory in the current directory
                case "mkdir":
                    {
                        if (tokens.Length != 1)
                        {
                            OutputWriter.DisplayException(
                                ExceptionMessages.params_InvalidNumber);
                            return;
                        }
                        string directoryName = tokens[0];
                        SessionData.CreateDirectoryInCurrentDirectory(directoryName);
                    } break;

                //ls
                //traverse the current directory to the given depth
                case "ls":
                    {
                        if (tokens.Length != 1)
                        {
                            OutputWriter.DisplayException(
                                string.Format(ExceptionMessages.params_InvalidNumber, 1));
                            return;
                        }
                        int depth;
                        if (!int.TryParse(tokens[0], out depth))
                        {
                            OutputWriter.DisplayException(
                                string.Format(ExceptionMessages.params_InvalidParameter, tokens[0]));
                            return;
                        }
                        IOManager.TraversingCurrentDirectory(depth);
                    } break;

                //cmp absolutePath1 absolutePath2
                //comparing two files by given two absolute paths
                case "cmp":
                    {
                        if (tokens.Length != 2)
                        {
                            OutputWriter.DisplayException(
                                string.Format(ExceptionMessages.params_InvalidNumber, 2));
                            return;
                        }
                        string filePath1 = tokens[0];
                        string filePath2 = tokens[1];
                        IOManager.CompareTwoFiles(filePath1, filePath2);
                    } break;

                //changeDirRel relativePath
                //change the current directory by a relative path
                case "changeDirRel":
                    {
                        if (tokens.Length != 1)
                        {
                            OutputWriter.DisplayException(
                                string.Format(ExceptionMessages.params_InvalidNumber, 1));
                            return;
                        }
                        string relativePath = tokens[0];
                        SessionData.ChangeCurrentDirectoryByRelativePath(relativePath);
                    } break;

                //changeDirAbs absolutePath
                //change the current directory by an absolute path
                case "changeDirAbs":
                    {
                        if (tokens.Length != 1)
                        {
                            OutputWriter.DisplayException(
                                string.Format(ExceptionMessages.params_InvalidNumber, 1));
                            return;
                        }
                        string absolutPath = tokens[0];
                        SessionData.ChangeCurrentDirectory(absolutPath);
                    } break;
                
                //open fileName
                //opens a file
                case "open":
                    {
                        if (tokens.Length != 1)
                        {
                            OutputWriter.DisplayException(
                                string.Format(ExceptionMessages.params_InvalidNumber, 1));
                            return;
                        }
                        string fileName = tokens[0];
                        IOManager.OpenFileWithDefaultProgram(fileName);
                    } break;

                //readDb dataBaseFileName
                //read students database by a given name of the database file
                //which is placed in the current folder
                case "readDb":
                    {

                    } break;

                //filter courseName poor/average/excellent take 2/10/42/all
                //filter students from а given course by a given filter option
                //and add quantity of students to take
                case "filter": break;

                //order courseName ascending/descending take 3/26/52/all
                //order student from a given course by ascending or descending order
                //and then take some of them or all that match it
                case "order": break;

                //download pathOfFile
                //download a file
                case "download": break;

                //downloadAsynch pathOfFile
                //download file asynchronously
                case "downloadAsynch": break;

                //help
                case "help": break;
                
                default:
                    break;
            }
        }

        private static void CheckNumberOfParameters(int num, string[] tokens)
        {

        }
    }
}
