namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using StaticData;
    using IO.Interfaces;
    using Models.Interfaces;
    using Repository.Interfaces;
    //
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Returns list of students from given course sorted in ascending or descending order.
    /// </summary>
    /// <example>order {0_courseName} {1_ascending/descending} {2_(int)number/(string)all}</example>

    public class OrderCommand : Command
    {
        private const int argumentsNumber = 3;

        private IRepository studentsRepository;
        private ISorter studentSorter;
        private IFormat formatToPrint;
        private IWriter consoleWriter;

        public OrderCommand(
            string[] arguments, 
            IRepository studentsRepository,
            ISorter studentSorter,
            IFormat formatToPrint,
            IWriter consoleWriter) 
            : base(arguments, argumentsNumber)
        {
            this.studentsRepository = studentsRepository;
            this.studentSorter = studentSorter;
            this.formatToPrint = formatToPrint;
            this.consoleWriter = consoleWriter;
        }

        public override void Execute()
        {
            ICourse course = this.studentsRepository
                .GetCourse(base.Arguments[0]);

            string order = base.Arguments[1];

            int take = 0;
            if (!int.TryParse(base.Arguments[2], out take))
            {
                if (base.Arguments[2] != "all")
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.params_InvalidParameter, base.Arguments[2]));
                }

                take = course.Students.Count;
            }

            IList<IStudent> sortedStudents = this.studentSorter
                .SortInterpreter(course, order, take);

            this.consoleWriter.WriteOneLineMessage(course.ToString());
            this.consoleWriter.WriteOneLineMessage(
                this.formatToPrint.StudentsToString(sortedStudents, course));
        }
    }
}
