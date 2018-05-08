namespace BashSoft_OOP
{
    using BashSoft_OOP.Interface;
    using BashSoft_OOP.StaticData;
    using BashSoft_OOP.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StudentsRepository : IStudentsRepository
    {
        //Dictionary<CourseName, CourseObject>
        private Dictionary<string, ICourse> courses;

        private IWriter consoleWriter;
        private IReader consoleReader;

        public StudentsRepository(IWriter consoleWriter, IReader consoleReader)
        {
            this.courses = new Dictionary<string, ICourse>();
            this.consoleWriter = consoleWriter;
            this.consoleReader = consoleReader;
        }

        public IReadOnlyDictionary<string, ICourse> Courses =>  this.courses;

        public int CoursesCount => this.courses.Count;

        public ICourse GetCourse(string courseName)
        {
            if (!this.courses.ContainsKey(courseName))
            {
                this.consoleWriter.WriteException(string.Format(
                    ExceptionMessages.data_Cours_NotExist, courseName));

                return null;
            }

            return this.courses[courseName];
        }

        public void ReadDataFromConsole()
        {
            int prevCount = this.CoursesCount;

            this.consoleWriter.WriteOneLineMessage("Reading data...");

            string input = this.consoleReader.ReadLine();

            while (true)
            {
                if (this.ShouldEnd(input))
                    break;

                ProcessingInput(input);

                input = this.consoleReader.ReadLine();
            }

            this.IsDataImported(prevCount);
        }

        private void IsDataImported(int prevCount)
        {
            if (this.CoursesCount > prevCount)
            {
                this.consoleWriter.WriteOneLineMessage("Data imported.");
            }
            else
            {
                this.consoleWriter.WriteOneLineMessage("Nothing imported!");
            }
        }

        public void ReadDataFromFile(string path)
        {
            if (!File.Exists(path))
            {
                this.consoleWriter.WriteException(
                    string.Format(ExceptionMessages.file_DoseNotExist, Path.GetFileName(path)));
                return;
            }

            int prevCount = this.CoursesCount;

            this.consoleWriter.WriteOneLineMessage("Reading data...");

            string[] input = File.ReadAllLines(path);

            for (int i = 0; i < input.Length; i++)
            {
                ProcessingInput(input[i]);
            }

            this.IsDataImported(prevCount);
        }

        //Input format – {1_CourseName_CourseInstance}{WhiteSpaces}{2_Username}{WhiteSpaces}{3_Scores}
        private void ProcessingInput(string input)
        {
            Match match = Regex.Match(input, 
                Constants.Pattern_InitializeRepository);

            if (!match.Success)
                return;

            string courseName = match.Groups[1].Value;
            string studentName = match.Groups[2].Value;

            int[] scores = null;

            try
            {
                scores = Utility.SplitInput(match.Groups[3].Value, " ")
                    .Select(int.Parse)
                    .ToArray();
            }
            catch
            {
                this.consoleWriter.WriteException(
                    string.Format(ExceptionMessages.data_Student_InvalidScores, studentName));
            }

            //if (scores.Length == 0)
            //    return;

            ICourse course = new Course(courseName);
            IStudent student = new Student(studentName);

            try
            {
                student.EnrollInCourse(course);
                student.AddTestScorsByCourse(courseName, scores);
            }
            catch (Exception ex)
            {
                this.consoleWriter.WriteException(ex.Message);
            }

            if (!this.courses.ContainsKey(courseName))
            {
                this.courses.Add(courseName, course);
            }

            this.courses[courseName].EnrollStudent(student);
        }

        private bool ShouldEnd(string input) => string.IsNullOrEmpty(input);
    }
}
