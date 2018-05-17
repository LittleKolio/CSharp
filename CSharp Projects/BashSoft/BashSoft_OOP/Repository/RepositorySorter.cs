namespace BashSoft_OOP.Repository
{
    using Interfaces;
    using Models.Interfaces;
    using StaticData;
    //
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
                        .OrderBy(s => s.GetTestScoresByCourse(course.Name)
                            .Where(m => m > -1)
                            .Average()
                        )
                        .Take(take)
                        .ToList();
                    break;

                case "descending":
                    sortedStudents = course
                        .Students
                        .OrderByDescending(s => s.GetTestScoresByCourse(course.Name)
                            .Where(m => m > -1)
                            .Average()
                        )
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
