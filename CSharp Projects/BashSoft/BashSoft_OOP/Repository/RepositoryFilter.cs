namespace BashSoft_OOP.Repository
{
    using Interfaces;
    using Models.Interfaces;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilter : IFilter
    {
        private Dictionary<string, Func<double, bool>> filterFunctions = new Dictionary<string, Func<double, bool>>
        {
            { "excellent", mark => mark >= 5.0 },
            { "average", mark => mark < 5.0 && mark >= 3.5 },
            { "poor", mark => mark < 3.5 }
        };

        public IList<IStudent> FilterInterpreter(
            ICourse course,
            string filter,
            int take)
        {
            if (course.Students.Count == 0)
            {
                throw new InvalidOperationException(string.Format(
                    ExceptionMessages.data_Student_NoStudents, course.Name));
            }

            if (!filterFunctions.ContainsKey(filter))
            {
                throw new ArgumentException(
                    ExceptionMessages.data_Filter_Invalid);

            }

            IList<IStudent> filteredStudents = null;

            filteredStudents = FilterByScoreAndTake(
                course, this.filterFunctions[filter], take);

            if (filteredStudents.Count == 0)
            {
                throw new NullReferenceException(
                    ExceptionMessages.data_Student_Requirements);
            }

            return filteredStudents;
        }

        private IList<IStudent> FilterByScoreAndTake(
            ICourse course,
            Func<double, bool> filter,
            int take)
        {
            IList<IStudent> filteredStudents = null;

            int count = 0;
            foreach (IStudent student in course.Students)
            {
                if (count == take)
                {
                    break;
                }

                double mark = student
                    .GetTestScoresByCourse(course.Name)
                    .Average();

                if (filter(mark))
                {
                    filteredStudents.Add(student);
                    count++;
                }
            }

            return filteredStudents;
        }
    }
}
