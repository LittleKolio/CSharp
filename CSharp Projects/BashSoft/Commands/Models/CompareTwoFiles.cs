namespace BashSoft.Commands.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CompareTwoFiles : ICmd
    {

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
            set { fileTwoPath = value; }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
