namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class RepositorySorter
    {
        public List<IStudent> SortInterpreter(
            List<IStudent> course,
            string order,
            string take)
        {
            int numberOfStudents;
            bool isNumber = int.TryParse(take, out numberOfStudents);
            if (!isNumber)
            {
                numberOfStudents = course.Count;
            }

            List<IStudent> sortedStudents = new List<IStudent>();

            switch (order)
            {
                case "ascending":
                    sortedStudents = course.OrderBy(s => s)
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
