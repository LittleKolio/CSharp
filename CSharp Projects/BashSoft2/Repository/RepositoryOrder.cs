namespace BashSoft2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Somebody said: We should forget about small efficiencies, 
    /// say about 97% of the time: premature optimization is the root of all evil. 
    /// Yet we should not pass up our opportunities in that critical 3%.
    /// ... mmmmmee i am evil!
    /// LINQ makes OrderByScore totally unnecessary
    /// </summary>
    public class RepositoryOrder
    {
        private static Dictionary<string, List<int>> data;
        public static Dictionary<string, List<int>> OrderInterpreter(
            string courseName, string order, string take)
        {
            data = StudentsRepository.GetAllStudents(courseName);

            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = data.Count;
            }

            //return data.OrderBy(s => s.Value.Average())
            //    .Take(numberOfStudents)
            //    .ToDictionary(s => s.Key, s => s.Value);

            switch (order)
            {
                case "ascending": return OrderByScore(CompareByScoresAscending, numberOfStudents);
                case "descending": return OrderByScore(CompareByScoresDescending, numberOfStudents);
                default:
                    OutputWriter.DisplayException(
               ExceptionMessages.data_InvalidOrder);
                    return null;
            }
        }

        private static Dictionary<string, List<int>> OrderByScore(
            Func<List<int>, List<int>, int> orderFunc, int numberOfStudents)
        {
            Dictionary<string, List<int>> sortedStudents 
                = new Dictionary<string, List<int>>();

            int count = 0;

            while (count < numberOfStudents)
            {
                KeyValuePair<string, List<int>> prevStudent 
                    = new KeyValuePair<string, List<int>>();

                foreach (KeyValuePair<string, List<int>> currentStudent in data)
                {
                    if (!string.IsNullOrEmpty(prevStudent.Key) && 
                        !sortedStudents.ContainsKey(currentStudent.Key))
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

        private static int CompareByScoresAscending(
            List<int> fistStudent, List<int> secondStudent)
        {
            return secondStudent.Average().CompareTo(fistStudent.Average());
        }

        private static int CompareByScoresDescending(
            List<int> fistStudent, List<int> secondStudent)
        {
            return fistStudent.Average().CompareTo(secondStudent.Average());
        }
    }
}
