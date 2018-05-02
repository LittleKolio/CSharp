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

            List<IStudent> sortedStudents = new List<IStudent>();

            switch (order)
            {
                case "ascending":
                    sortedStudents = course.Students.OrderBy(s => 
                        s.Value.TestScorsByCourse(course.Name))
                        .Take(take)
                        .Select(s => s.Value)
                        .ToList();
                    break;

                case "descending":
                    sortedStudents = course.Students.OrderByDescending(s => 
                        s.Value.TestScorsByCourse(course.Name))
                        .Take(take)
                        .Select(s => s.Value)
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
