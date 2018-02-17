namespace BashSoft2.Engine
{
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
                case "mkdir": break;

                //ls
                //traverse the current directory to the given depth
                case "ls": break;

                //cmp absolutePath1 absolutePath2
                //comparing two files by given two absolute paths
                case "cmp": break;

                //changeDirRel relativePath
                //change the current directory by a relative path
                case "changeDirRel": break;

                //changeDirAbs absolutePath
                //change the current directory by an absolute path
                case "changeDirAbs": break;
                
                //open
                //opens a file
                case "open": break;

                //readDb dataBaseFileName
                //read students database by a given name of the database file
                //which is placed in the current folder
                case "readDb": break;

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
    }
}
