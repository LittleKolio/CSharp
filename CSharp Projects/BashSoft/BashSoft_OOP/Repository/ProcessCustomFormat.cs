namespace BashSoft_OOP.Repository
{
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;
    using StaticData;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Util;

    public class ProcessCustomFormat : IProcessCustomFormat
    {
        private IRepository repository;
        private IWriter consoleWriter;
        private IReader consoleReader;

        public ProcessCustomFormat(
            IRepository repository, 
            IWriter consoleWriter, 
            IReader consoleReader)
        {
            this.repository = repository;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        private void IsDataImported(int prevCount)
        {
            if (this.repository.Count > prevCount)
            {
                this.consoleWriter.WriteOneLineMessage("Data imported.");
            }
            else
            {
                this.consoleWriter.WriteOneLineMessage("Nothing imported!");
            }
        }

        public void ReadDataFromConsole()
        {
            int prevCount = this.repository.Count;

            this.consoleWriter.WriteOneLineMessage("Reading data...");

            string input = this.consoleReader.ReadLine();

            while (true)
            {
                if (this.ShouldEnd(input))
                {
                    break;
                }

                ProcessingCustomFormat(input);

                input = this.consoleReader.ReadLine();
            }

            this.IsDataImported(prevCount);
        }

        private bool ShouldEnd(string input) => string.IsNullOrEmpty(input);

        public void ReadDataFile(string path)
        {
            string[] input = null;
            try
            {
                input = File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                this.consoleWriter.WriteException(ex.Message);
            }

            int prevCount = this.repository.Count;

            this.consoleWriter.WriteOneLineMessage("Reading data...");

            for (int i = 0; i < input.Length; i++)
            {
                ProcessingCustomFormat(input[i]);
            }

            this.IsDataImported(prevCount);
        }

        //Input format – {0_CourseName_CourseInstance} {1_Username} {2_Scores}
        private void ProcessingCustomFormat(string input)
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

            ICourse course = new Course(courseName, 5);
            IStudent student = new Student(studentName);

            try
            {
                student.EnrollInCourse(course);
                student.AddTestScoresByCourse(courseName, scores);
                course.EnrollStudent(student);
                this.repository.AddCourse(course);
            }
            catch (Exception ex)
            {
                this.consoleWriter.WriteException(ex.Message);
            }
        }
    }
}
