namespace BashSoft_OOP.IO
{
    using Interfaces;
    using Models.Interfaces;
    using StaticData;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FormatToPrint : IFormat
    {
        public string CoursesToString(List<ICourse> courses, IStudent student)
        {
            StringBuilder sb = new StringBuilder();

            int count = 1;
            foreach (ICourse course in courses)
            {
                List<int> testScores = student.GetTestScoresByCourse(course.Name);
                string testScoresToString = string.Join(" ", testScores);
                double average = testScores.Average();

                sb.AppendFormat(Constants.Format_ListOfCourses
                    + Environment.NewLine,
                    count,
                    "\u2500\u2524",
                    course.Name.PadRight(Constants.Padding_Name),
                    average,
                    testScoresToString);

                count++;
            }

            return sb.ToString().TrimEnd();
        }

        public string StudentsToString(IList<IStudent> students, ICourse course)
        {
            StringBuilder sb = new StringBuilder();

            int count = 1;
            foreach (IStudent student in students)
            {
                List<int> testScores = student.GetTestScoresByCourse(course.Name);
                string testScoresToString = string.Join(" ", testScores);
                double average = testScores.Average();

                sb.AppendFormat(Constants.Format_ListOfStudents 
                    + Environment.NewLine,
                    count,
                    "\u2500\u2524",
                    student.Name.PadRight(Constants.Padding_Name),
                    average,
                    testScoresToString);

                count++;
            }

            return sb.ToString().TrimEnd();
        }

        //public string Box(string type, params string[] str)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendFormat("┌{0}{1}┐" + Environment.NewLine,
        //        type, new string('─', str[0].Length - type.Length));

        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        sb.AppendFormat("│{0}│" + Environment.NewLine, str[i]);
        //    }

        //    sb.AppendFormat("└{0}┘" + Environment.NewLine, 
        //        new string('─', str[str.Length - 1].Length));

        //    return sb.ToString().TrimEnd();
        //}
    }
}
