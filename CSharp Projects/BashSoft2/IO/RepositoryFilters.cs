namespace BashSoft2.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public static class RepositoryFilters
    {
        public static void OrderBy(string courseName, string filter, string take)
        {
            Dictionary<string, List<int>> data = StudentsRepository.GetAllStudents(courseName);
            Dictionary<string, List<int>> sorted = new Dictionary<string, List<int>>();

            int takenCount = 0;
            bool isSorted = false;

            while (true)
            {
                isSorted = true;
                KeyValuePair<string, List<int>> temp = new KeyValuePair<string, List<int>>();
                foreach (KeyValuePair<string, List<int>> student in data)
                {
                    if (!string.IsNullOrEmpty(temp.Key))
                    {
                        int compareResult = student.Value.Sum().CompareTo(temp.Value.Sum());
                        if (compareResult >= 0 && !sorted.ContainsKey(student.Key))
                        {
                            temp = student;
                            isSorted = false;
                        }
                    }
                    else
                    {
                        if (!sorted.ContainsKey(student.Key))
                        {
                            temp = student;
                            isSorted = false;
                        }
                    }
                }

                if (isSorted)
                {
                    sorted.Add(temp.Key, temp.Value);
                    takenCount++;
                    temp = new KeyValuePair<string, List<int>>();
                }
            }
        }

        private static int CompareStudentsByScores(List<int> fistStudent, List<int> secondStudent)
        {
            return fistStudent.Sum().CompareTo(secondStudent.Sum());
        }

        public static void FilterInterpreter(string courseName, string filter, string take)
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
                case "excellent": FilterByScore(data, ExcellentFilter, numberOfStudents); break;
                case "average": FilterByScore(data, AverageFilter, numberOfStudents); break;
                case "poor": FilterByScore(data, PoorFilter, numberOfStudents); break;
                default:
                    OutputWriter.DisplayException(
               ExceptionMessages.data_InvalidFilter);
                    break;
            }
        }
        private static void FilterByScore(
            Dictionary<string, List<int>> data,
            Predicate<double> filter,
            int numberOfStudents
            )
        {
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
                    OutputWriter.PrintStudent(student);
                    count++;
                }
            }
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
