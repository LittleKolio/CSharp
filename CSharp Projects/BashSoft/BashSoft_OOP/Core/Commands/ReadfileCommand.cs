using BashSoft_OOP.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft_OOP.Core.Commands
{
    /// <summary>
    /// Initialize (fill) the database from file by given name.
    /// First we have to change directory
    /// </summary>
    public class ReadfileCommand : Command
    {
        private IStudentsRepository studentsRepository;
        private IFilesystemManager filesystemManager;

        public ReadfileCommand(
            string[] arguments, 
            IStudentsRepository studentsRepository, 
            IFilesystemManager filesystemManager) 
            : base(arguments)
        {
            this.studentsRepository = studentsRepository;
            this.filesystemManager = filesystemManager;
        }

        public override void Execute()
        {
            string fileName = base.Arguments[0];

            string path = Path.Combine(this.filesystemManager.CurrentDirectory, fileName);

            this.studentsRepository.ReadDataFromFile(path);
        }
    }
}
