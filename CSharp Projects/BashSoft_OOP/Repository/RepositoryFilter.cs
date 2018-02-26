namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilter
    {
        public Dictionary<string, List<int>> FilterInterpreter(
            Dictionary<string, List<int>> course,
            string filter, 
            string take)
        {
            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = course.Count;
            }

            Dictionary<string, List<int>> filteredStudents
                = new Dictionary<string, List<int>>();

            switch (filter)
            {
                case "excellent":
                    filteredStudents = FilterByScoreAndTake(
                    course, ExcellentFilter, numberOfStudents);
                    break;

                case "average":
                    filteredStudents = FilterByScoreAndTake(
                    course, AverageFilter, numberOfStudents);
                    break;

                case "poor":
                    filteredStudents = FilterByScoreAndTake(
                    course, PoorFilter, numberOfStudents);
                    break;

                default: OutputWriter.DisplayException(
                    ExceptionMessages.data_InvalidFilter);
                    break;
            }

            if (filteredStudents.Count == 0)
            {
                OutputWriter.WriteOneLineMessage(
                    ExceptionMessages.data_NoStudent);
            }

            return filteredStudents;
        }
        private Dictionary<string, List<int>> FilterByScoreAndTake(
            Dictionary<string, List<int>> course,
            Predicate<double> filter, 
            int numberOfStudents)
        {
            Dictionary<string, List<int>> filteredStudents 
                = new Dictionary<string, List<int>>();

            int count = 0;
            foreach (KeyValuePair<string, List<int>> student in course)
            {
                if (count == numberOfStudents)
                {
                    break;
                }

                double mark = Average(student.Value);
                if (filter(mark))
                {
                    filteredStudents.Add(student.Key, student.Value);
                    count++;
                }
            }

            return filteredStudents;
        }

        private bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }
        private bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
        }
        private bool PoorFilter(double mark)
        {
            return mark < 3.5;
        }
        private double Average(List<int> scores)
        {
            double percentTotalScore = scores.Average() / 100;
            return percentTotalScore * 4 + 2;
        }
    }
}
