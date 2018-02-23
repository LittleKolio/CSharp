namespace BashSoft2.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public static class RepositoryFilters
    {
        public static Dictionary<string, List<int>> OrderInterpreter(string courseName, string order, string take)
        {
            Dictionary<string, List<int>> data = StudentsRepository.GetAllStudents(courseName);

            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = data.Count;
            }

            switch (order)
            {
                case "ascending": return OrderByScore(data, CompareByScoresAscending, numberOfStudents);
                case "descending": return OrderByScore(data, CompareByScoresDescending, numberOfStudents);
                default: OutputWriter.DisplayException(
                    ExceptionMessages.data_InvalidOrder);
                    return null;
            }
        }

        private static Dictionary<string, List<int>> OrderByScore(
            Dictionary<string, List<int>> data,
            Func<List<int>, List<int>, int> orderFunc,
            int numberOfStudents
            )
        {
            Dictionary<string, List<int>> sortedStudents = new Dictionary<string, List<int>>();
            int count = 0;

            while (count < numberOfStudents)
            {
                KeyValuePair<string, List<int>> prevStudent = new KeyValuePair<string, List<int>>();

                foreach (KeyValuePair<string, List<int>> currentStudent in data)
                {
                    if (!string.IsNullOrEmpty(prevStudent.Key) && !sortedStudents.ContainsKey(currentStudent.Key))
                    {
                        int compareResult = orderFunc(currentStudent.Value, prevStudent.Value);
                        if (compareResult >= 0)
                        {
                            prevStudent = currentStudent;
                        }
                    }
                    else if (!sortedStudents.ContainsKey(currentStudent.Key))
                    {
                        prevStudent = currentStudent;
                    }
                }

                sortedStudents.Add(prevStudent.Key, prevStudent.Value);
                count++;
            }

            return sortedStudents;
        }

        public static Dictionary<string, List<int>> FilterInterpreter(string courseName, string filter, string take)
        {
            Dictionary<string, List<int>> data = StudentsRepository.GetAllStudents(courseName);

            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = data.Count;
            }

            switch (filter)
            {
                case "excellent": return FilterByScore(data, ExcellentFilter, numberOfStudents);
                case "average": return FilterByScore(data, AverageFilter, numberOfStudents);
                case "poor": return FilterByScore(data, PoorFilter, numberOfStudents);
                default: OutputWriter.DisplayException(
                    ExceptionMessages.data_InvalidFilter);
                    return null;
            }
        }
        private static Dictionary<string, List<int>> FilterByScore(
            Dictionary<string, List<int>> data,
            Predicate<double> filter,
            int numberOfStudents
            )
        {
            Dictionary<string, List<int>> filteredStudents = new Dictionary<string, List<int>>();

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

        private static int CompareByScoresAscending(List<int> fistStudent, List<int> secondStudent)
        {
            return secondStudent.Average().CompareTo(fistStudent.Average());
        }

        private static int CompareByScoresDescending(List<int> fistStudent, List<int> secondStudent)
        {
            return fistStudent.Average().CompareTo(secondStudent.Average());
        }
    }
}
