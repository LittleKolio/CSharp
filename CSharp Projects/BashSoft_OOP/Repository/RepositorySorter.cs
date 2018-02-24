namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class RepositorySorter
    {
        private Dictionary<string, List<int>> data;
        public Dictionary<string, List<int>> OrderInterpreter(
            string courseName, string order, string take)
        {
            this.data = StudentsRepository.GetAllStudents(courseName);

            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = data.Count;
            }

            switch (order)
            {
                case "ascending":
                    return data.OrderBy(s => AverageOfList(s.Value))
                        .Take(numberOfStudents)
                        .ToDictionary(s => s.Key, s => s.Value);

                case "descending":
                    return data.OrderByDescending(s => AverageOfList(s.Value))
                        .Take(numberOfStudents)
                        .ToDictionary(s => s.Key, s => s.Value);
                default:
                    OutputWriter.DisplayException(
               ExceptionMessages.data_InvalidOrder);
                    return null;
            }
        }

        private Func<List<int>, double> AverageOfList = s => s.Average();
    }
}
