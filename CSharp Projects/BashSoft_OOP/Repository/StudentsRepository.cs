namespace BashSoft_OOP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class StudentsRepository
    {
        private const string pattern = @"([A-Z][#\+a-zA-Z]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{3,}\d{2}_\d{2,4})\s+(\d+)";

        //Dictionary<CourseName, Dictionary<StudentName, List<grade>>>
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private bool isDataInitialized = false;
        private RepositoryFilter filter;
        private RepositorySorter sorter;


        public StudentsRepository(RepositoryFilter filter, RepositorySorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();

        }

        public void ReadDataFromConsole()
        {
            int count = studentsByCourse.Count;
            OutputWriter.WriteOneLineMessage("Reading data...");

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                ProcessingInput(input);
            }

            if (studentsByCourse.Count > count)
            {
                OutputWriter.WriteOneLineMessage("Data imported.");
                this.isDataInitialized = true;
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
                OutputWriter.DisplayException(
                    string.Format(ExceptionMessages.file_DoseNotExist, name));
                return;
            }

            int count = studentsByCourse.Count;
            OutputWriter.WriteOneLineMessage("Reading data...");

            string[] input = File.ReadAllLines(path);
            for (int i = 0; i < input.Length; i++)
            {
                ProcessingInput(input[i]);
            }

            if (studentsByCourse.Count > count)
            {
                OutputWriter.WriteOneLineMessage("Data imported.");
                this.isDataInitialized = true;
            }
            else
            {
                OutputWriter.WriteOneLineMessage(
                    "Nothing imported!");
            }
        }

        //Input format – {Course Name}_{Course Instance}{One or more white spaces}{Username}{One or more white spaces}{Score}
        private void ProcessingInput(string input)
        {
            Match match = Regex.Match(input, pattern);

            if (string.IsNullOrWhiteSpace(input) || !match.Success)
            {
                return;
            }

            string courseName = match.Groups[1].Value;
            string studentName = match.Groups[2].Value;
            int score;
            bool isScore = int.TryParse(match.Groups[3].Value, out score);

            if (!isScore || score < 0 || score > 100)
            {
                return;
            }

            if (!IsQueryForCoursePossible(courseName))
            {
                studentsByCourse.Add(courseName,
                    new Dictionary<string, List<int>>());
            }

            if (!IsQueryForStudentPossiblе(courseName, studentName))
            {
                studentsByCourse[courseName].Add(studentName, new List<int>());
            }

            studentsByCourse[courseName][studentName].Add(score);
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                return studentsByCourse.ContainsKey(courseName);
            }
            else
            {
                OutputWriter.DisplayException(
                    ExceptionMessages.data_IsNotInitialized);
            }
            return false;
        }

        private bool IsQueryForStudentPossiblе(string courseName, string studentName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return studentsByCourse[courseName].ContainsKey(studentName);
                }
                else
                {
                    OutputWriter.DisplayException(
                        ExceptionMessages.data_CoursDoseNotExist);
                }
            }
            else
            {
                OutputWriter.DisplayException(
                    ExceptionMessages.data_IsNotInitialized);
            }

            return false;
        }

        public List<int> GetStudent(string courseName, string studentName)
        {
            if (IsQueryForStudentPossiblе(courseName, studentName))
            {
                return studentsByCourse[courseName][studentName];

                //OutputWriter.PrintStudent(
                //    new KeyValuePair<string, List<int>>(
                //        studentName, studentsByCourse[courseName][studentName]));
            }
            return null;
        }
        public Dictionary<string, List<int>> GetAllStudents(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                return studentsByCourse[courseName];

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
