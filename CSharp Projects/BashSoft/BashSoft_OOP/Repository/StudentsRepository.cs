namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StudentsRepository
    {
        private const string pattern = @"([A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";

        //Dictionary<CourseName, Course>
        private Dictionary<string, Course> courses;
        private bool isDataInitialized = false;

        public StudentsRepository()
        {
            this.courses = new Dictionary<string, Course>();
            this.isDataInitialized = true;
        }

        public IDictionary<string, Course> Courses =>  this.courses;

        public int CoursesCount => this.courses.Count;

        public void ReadDataFromConsole()
        {
            int prevCount = this.CoursesCount;
            OutputWriter.WriteOneLineMessage("Reading data...");

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                ProcessingInput(input);
            }

            if (this.CoursesCount > prevCount)
            {
                OutputWriter.WriteOneLineMessage("Data imported.");
            }
            else
            {
                OutputWriter.WriteOneLineMessage(
                    "Nothing imported!");
            }

        }
        public void ReadDataFromFile(string name)
        {
            string path = Path.Combine(FilesystemOperations.currentDirectory, name);

            if (!File.Exists(path))
            {
                OutputWriter.WriteException(
                    string.Format(ExceptionMessages.file_DoseNotExist, name));
                return;
            }

            int count = courses.Count;
            OutputWriter.WriteOneLineMessage("Reading data...");

            string[] input = File.ReadAllLines(path);
            for (int i = 0; i < input.Length; i++)
            {
                ProcessingInput(input[i]);
            }

            if (courses.Count > count)
            {
                OutputWriter.WriteOneLineMessage("Data imported.");
            }
            else
            {
                OutputWriter.WriteOneLineMessage(
                    "Nothing imported!");
            }
        }

        //Input format – {1_CourseName_CourseInstance}{WhiteSpaces}{2_Username}{WhiteSpaces}{3_Scores}
        private void ProcessingInput(string input)
        {
            Match match = Regex.Match(input, pattern);

            if (string.IsNullOrWhiteSpace(input) || !match.Success)
            {
                return;
            }

            string courseName = match.Groups[1].Value;
            string studentName = match.Groups[2].Value;
            int[] scores;
            try
            {
                scores = this.SplitInput(match.Groups[3].Value, " ");
            }
            catch
            {
                throw new ArgumentException("Invalid score!");
            }

            if (scores.Length == 0)
            {
                return;
            }

            Course course = new Course(courseName);
            Student student = new Student(studentName);
            student.Courses.Add(courseName, course);
            student.AddTestScorByCourse(courseName, scores);


            if (!courses.ContainsKey(courseName))
            {
                courses.Add(courseName, course);
            }

            courses[courseName].EnrollStudent(student);
        }

        private int[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private Func<int, bool> 

        public List<int> GetStudent(string courseName, string studentName)
        {
            if (IsQueryForStudentPossiblе(courseName, studentName))
            {
                return courses[courseName][studentName];

                //OutputWriter.PrintStudent(
                //    new KeyValuePair<string, List<int>>(
                //        studentName, studentsByCourse[courseName][studentName]));
            }
            return null;
        }
        public Dictionary<string, List<int>> GetCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                return courses[courseName];

                //OutputWriter.WriteOneLineMessage(courseName);
                //foreach (var student in studentsByCourse[courseName])
                //{
                //    OutputWriter.PrintStudent(student);
                //}
            }
            return null;
        }
    }
}
