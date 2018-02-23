namespace BashSoft2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RepositoryFilters
    {
        private static Dictionary<string, List<int>> data;
        public static Dictionary<string, List<int>> FilterInterpreter(
            string courseName, string filter, string take)
        {
            data = StudentsRepository.GetAllStudents(courseName);

            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = data.Count;
            }

            switch (filter)
            {
                case "excellent": return FilterByScore(ExcellentFilter, numberOfStudents);
                case "average": return FilterByScore(AverageFilter, numberOfStudents);
                case "poor": return FilterByScore(PoorFilter, numberOfStudents);
                default: OutputWriter.DisplayException(
                    ExceptionMessages.data_InvalidFilter);
                    return null;
            }
        }
        private static Dictionary<string, List<int>> FilterByScore(
            Predicate<double> filter, int numberOfStudents)
        {
            Dictionary<string, List<int>> filteredStudents 
                = new Dictionary<string, List<int>>();

            int count = 0;
            foreach (KeyValuePair<string, List<int>> student in data)
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

        private static bool ExcellentFilter(double mark)
        {
            return mark >= 5.0;
        }
        private static bool AverageFilter(double mark)
        {
            return mark < 5.0 && mark >= 3.5;
        }
        private static bool PoorFilter(double mark)
        {
            return mark < 3.5;
        }
        private static double Average(List<int> scores)
        {
            double percentTotalScore = scores.Average() / 100;
            return percentTotalScore * 4 + 2;
        }
    }
}
