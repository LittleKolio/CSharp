namespace BashSoft.Commands.Models
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Cmd(CmdEnum.cmp)]
    public class CompareTwoFiles : ICmd
    {
        private const string mismatchFormat
            = "Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"";

        private string fileOnePath;
        private string fileTwoPath;

        public CompareTwoFiles(string fileOnePath, string fileTwoPath)
        {
            this.FileOnePath = fileOnePath;
            this.FileTwoPath = fileTwoPath;
        }

        public string FileOnePath
        {
            get { return fileOnePath; }
            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException();
                }
                fileOnePath = value;
            }
        }

        public string FileTwoPath
        {
            get { return fileTwoPath; }
            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException();
                }
                fileTwoPath = value;
            }
        }

        public void Execute()
        {
            OutputWriter.WriteOneLineMessage("Reading files...");
            StringBuilder sb = new StringBuilder();

            try
            {
                string[] fileOneLines = File.ReadAllLines(this.fileOnePath);
                string[] fileTwoLines = File.ReadAllLines(this.fileTwoPath);

                string mismatchPath = CustomPath.PathForMismatches(this.fileTwoPath);

                int count = InitialCommpare(fileOneLines, fileTwoLines);

                for (int i = 0; i < count; i++)
                {
                    string input = "none";
                    string compareWith = "none";

                    if (fileOneLines.Length > i) { input = fileOneLines[i]; }
                    if (fileTwoLines.Length > i) { compareWith = fileTwoLines[i]; }

                    if (!input.Equals(compareWith))
                    {
                        sb.AppendLine(string.Format(
                            mismatchFormat, (i + 1), input, compareWith));
                    }
                }

                if (sb.Length > 0)
                {
                    File.WriteAllText(mismatchPath, sb.ToString());
                }
                else if (sb.Length == 0)
                {
                    OutputWriter.WriteOneLineMessage(
                        CustomMessages.FilesAreIdentical);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                OutputWriter.WriteExeption(ex.Message);
            }
        }

        private int InitialCommpare(string[] fileOneLines, string[] fileTwoLines)
        {
            int count = 0;

            if (fileOneLines.Length > fileTwoLines.Length)
            {
                OutputWriter.WriteOneLineMessage(
                    CustomMessages.FileOneHasMoreText);

                count = fileOneLines.Length;
            }

            if (fileOneLines.Length < fileTwoLines.Length)
            {
                OutputWriter.WriteOneLineMessage(
                    CustomMessages.FileTwoHasMoreText);

                count = fileTwoLines.Length;
            }

            if (fileOneLines.Length == fileTwoLines.Length)
            {
                count = fileTwoLines.Length;
            }

            return count;
        }
    }
}
