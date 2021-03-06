﻿namespace BashSoft_OOP.Core.Commands
{
    using Abstract;
    using IO.Interfaces;
    using Models.Interfaces;
    using Repository.Interfaces;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Returns list of students from given course who average score is:
    /// - poor when score is below 3.5
    /// - average when score is between 3.5 and 5
    /// - excellent  when score is above 5
    /// </summary>
    /// <example>filter {0_(string)courseName} {1_(string)poor/average/excellent} {2_(int)number/(string)all}</example>

    public class FilterCommand : Command
    {
        private const int argumentsNumber = 3;

        private IRepository courseRepository;
        private IFilter studentsFilter;
        private IFormat formatToPrint;
        private IWriter consoleWriter;

        public FilterCommand(
            string[] arguments,
            IRepository courseRepository,
            IFilter studentsFilter,
            IFormat formatToPrint,
            IWriter consoleWriter) 
            : base(arguments, argumentsNumber)
        {
            this.courseRepository = courseRepository;
            this.studentsFilter = studentsFilter;
            this.formatToPrint = formatToPrint;
            this.consoleWriter = consoleWriter;
        }

        public override void Execute()
        {
            ICourse course = this.courseRepository
                .GetCourse(base.Arguments[0]);

            string filter = base.Arguments[1];

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

            IList<IStudent> filteredStudents = this.studentsFilter
                .FilterInterpreter(course, filter, take);

            this.consoleWriter.WriteOneLineMessage(course.ToString());
            this.consoleWriter.WriteOneLineMessage(
                this.formatToPrint.StudentsToString(filteredStudents, course));
        }
    }
}
