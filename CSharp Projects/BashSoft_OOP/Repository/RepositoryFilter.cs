namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilter
    {
        private Dictionary<string, List<int>> data;
        public Dictionary<string, List<int>> FilterInterpreter(
            string courseName, string filter, string take)
        {
            this.data = StudentsRepository.GetAllStudents(courseName);

            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = this.data.Count;
            }

            switch (filter)
            {
                case "excellent": return FilterByScoreAndTake(
                    ExcellentFilter, numberOfStudents);

                case "average": return FilterByScoreAndTake(
                    AverageFilter, numberOfStudents);

                case "poor": return FilterByScoreAndTake(
                    PoorFilter, numberOfStudents);

                default: OutputWriter.DisplayException(
                    ExceptionMessages.data_InvalidFilter);
                    return null;
            }
        }
        private Dictionary<string, List<int>> FilterByScoreAndTake(
            Predicate<double> filter, int numberOfStudents)
        {
            Dictionary<string, List<int>> filteredStudents 
                = new Dictionary<string, List<int>>();

            int count = 0;
            foreach (KeyValuePair<string, List<int>> student in this.data)
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
