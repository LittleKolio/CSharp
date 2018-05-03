
namespace BashSoft_OOP.Core.Commands
{
    using BashSoft_OOP.Interface;
    using System;

    /// <summary>
    /// Sort students from a given course in ascending or descending order, then take first N't of them or all.
    /// </summary>
    /// <example>order {0_courseName} {1_ascending/descending} {2_(int)number/(string)all}</example>

    public class OrderCommand : Command
    {
        private const int argumentsNumber = 3;

        private IStudentsRepository studentsRepository;

        protected OrderCommand(
            string[] arguments, 
            IStudentsRepository studentsRepository) 
            : base(arguments, argumentsNumber)
        {
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
        }
    }
}
