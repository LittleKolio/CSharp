namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class RepositorySorter
    {
        public Dictionary<string, List<int>> SortInterpreter(
            Dictionary<string, List<int>> course,
            string order, 
            string take)
        {
            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = course.Count;
            }

            Dictionary<string, List<int>> sortedStudents
                = new Dictionary<string, List<int>>();

            switch (order)
            {
                case "ascending":
                    sortedStudents = course.OrderBy(s => AverageOfList(s.Value))
                        .Take(numberOfStudents)
                        .ToDictionary(s => s.Key, s => s.Value);
                    break;

                case "descending":
                    sortedStudents = course.OrderByDescending(s => AverageOfList(s.Value))
                        .Take(numberOfStudents)
                        .ToDictionary(s => s.Key, s => s.Value);
                    break;

                default:
                    ConsoleWriter.WriteException(
                        ExceptionMessages.data_Order_Invalid);
                    break;
            }

            if (sortedStudents.Count == 0)
            {
                ConsoleWriter.WriteOneLineMessage(
                    ExceptionMessages.data_Student_Requirements);
            }

            return sortedStudents;
        }

        private Func<List<int>, double> AverageOfList = s => s.Average();
    }
}
