namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class RepositorySorter : ISorter
    {
        public IList<IStudent> SortInterpreter(
            ICourse course,
            string order,
            int take)
        {
            if (course.Students.Count == 0)
            {
                throw new InvalidOperationException(
                    ExceptionMessages.data_Student_Requirements);
            }

            IList<IStudent> sortedStudents = null;

            switch (order)
            {
                case "ascending":
                    sortedStudents = course
                        .Students
                        .Select(s => s.Value)
                        .OrderBy(s => s.GetTestScorsByCourse(course.Name).Average())
                        .Take(take)
                        .ToList();
                    break;

                case "descending":
                    sortedStudents = course
                        .Students
                        .Select(s => s.Value)
                        .OrderByDescending(s => s.GetTestScorsByCourse(course.Name).Average())
                        .Take(take)
                        .ToList();
                    break;

                default:
                    throw new ArgumentException(
                        ExceptionMessages.data_Order_Invalid);
            }

            return sortedStudents;
        }

    }
}
