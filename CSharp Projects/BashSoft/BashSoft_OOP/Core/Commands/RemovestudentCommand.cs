namespace BashSoft_OOP.Core.Commands
{
    using System;
    using BashSoft_OOP.Core.Abstract;
    using Repository.Interfaces;
    using Models.Interfaces;
    using IO.Interfaces;
    using StaticData;

    /// <summary>
    /// Remove student from a given course.
    /// </summary>
    /// <example>removestudent {0_(string)courseName} {1_(string)studentName}</example>

    public class RemovestudentCommand : Command
    {
        private const int argumentsNumber = 2;

        private IRepository repository;
        private IWriter consoleWriter;

        public RemovestudentCommand(
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
            string studentName = base.Arguments[1];

            ICourse course = this.repository.GetCourse(courseName);
            course.RemoveStudent(studentName);

            this.consoleWriter.WriteOneLineMessage(string.Format(
                Constants.Remove_Student, studentName));
        }
    }
}
