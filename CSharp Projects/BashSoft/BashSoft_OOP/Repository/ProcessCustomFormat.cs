namespace BashSoft_OOP.Repository
{
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;
    using StaticData;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Util;

    public class ProcessCustomFormat : IProcessCustomFormat
    {
        private IRepository repository;
        private IFormat formatToPrint;
        private IWriter consoleWriter;
        private IReader consoleReader;

        public ProcessCustomFormat(
            IRepository repository,
            IFormat formatToPrint, 
            IWriter consoleWriter, 
            IReader consoleReader)
        {
            this.repository = repository;
            this.formatToPrint = formatToPrint;
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
                if (this.ShouldEnd(input)) { break; }

                ProcessingCustomFormat(input);

                input = this.consoleReader.ReadLine();
            }

            this.IsDataImported(prevCount);
        }

        private bool ShouldEnd(string input) => string.IsNullOrEmpty(input);

        public void ReadDataFile(string path)
        {
            int prevCount = this.repository.Count;

            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(path))
            {
                this.consoleWriter.WriteOneLineMessage("Reading data...");

                int count = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        ProcessingCustomFormat(line);
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine($"Line {count}: " + ex.Message);
                    }

                    count++;
                }
            }

            if (sb.Length != 0)
            {
                this.consoleWriter.WriteException(
                    sb.ToString().TrimEnd());
            }

            this.IsDataImported(prevCount);
        }

        //{0_CourseName_CourseInstance} {1_numberOfExams} {2_Username} {3_Scores}
        private void ProcessingCustomFormat(string input)
        {
            Match match = Regex.Match(input,
                Constants.Pattern_InitializeRepository);

            if (!match.Success) { return; }

            string courseName = match.Groups[1].Value;
            int numberOfExams = int.Parse(match.Groups[2].Value);
            string studentName = match.Groups[3].Value;

            int[] scores = null;

            try
            {
                scores = Utility.SplitInput(match.Groups[4].Value, " ")
                    .Select(int.Parse)
                    .ToArray();
            }
            catch
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.data_Student_InvalidScores, studentName));
            }

            //if (scores.Length == 0)
            //    return;

            ICourse course = new Course(courseName, numberOfExams);
            IStudent student = new Student(studentName);
            student.EnrollInCourse(course);
            student.AddTestScoresByCourse(courseName, scores);
            course.EnrollStudent(student);

            this.repository.AddCourse(course);
        }
    }
}
