namespace BashSoft_OOP.Core.Commands
{
    using System;
    using BashSoft_OOP.Core.Abstract;
    using Repository.Interfaces;
    using IO.Interfaces;
    using StaticData;

    /// <summary>
    /// Remove course from database.
    /// </summary>
    /// <example>removecourse {0_(string)courseName}</example>

    public class RemovecourseCommand : Command
    {
        private const int argumentsNumber = 1;

        private IRepository repository;
        private IWriter consoleWriter;

        public RemovecourseCommand(
            string[] arguments,
            IRepository repository,
            IWriter consoleWriter) 
            : base(arguments, argumentsNumber)
        {
            this.repository = repository;
            this.consoleWriter = consoleWriter;
        }

        public override void Execute()
        {
            string courseName = base.Arguments[0];

            this.repository.RemoveCourse(courseName);

            this.consoleWriter.WriteOneLineMessage(string.Format(
                Constants.Remove_Course, courseName));
        }
    }
}
