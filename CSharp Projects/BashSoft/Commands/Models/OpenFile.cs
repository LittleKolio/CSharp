using BashSoft.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Commands
{
    public class OpenFile : ICmd
    {
        private string fileName;

        public OpenFile(string fileName)
        {
            this.fileName = fileName;
        }

        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        private string Path()
        {
            return CustomPath.CurrentPath + "\\" + this.FileName;
        }

        public void Execute()
        {
            Process.Start(this.Path());
        }
    }
}
