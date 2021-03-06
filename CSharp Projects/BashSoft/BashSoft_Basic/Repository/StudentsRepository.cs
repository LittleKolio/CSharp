﻿namespace BashSoft_Basic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class StudentsRepository
    {
        private const string pattern = @"([A-Z][#\+a-zA-Z]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{3,}\d{2}_\d{2,4})\s+(\d+)";
        public static bool isDataInitialized = false;

        //Course name, student name, list of grades
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        private static void Initialize()
        {
            if (!isDataInitialized)
            {
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                isDataInitialized = true;

                OutputWriter.WriteOneLineMessage(
                    ExceptionMessages.data_IsInitialized);
            }
        }

        public static void ReadDataFromConsole()
        {
            Initialize();

            OutputWriter.WriteOneLineMessage("Reading data...");

            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                ProcessingInput(input);
            }

            OutputWriter.WriteOneLineMessage("Data read!");
        }
        public static void ReadDataFromFile(string name)
        {
            string path = Path.Combine(FilesystemOperations.currentDirectory, name);

            if (!File.Exists(path))
            {
                OutputWriter.DisplayException(
                    string.Format(ExceptionMessages.file_DoseNotExist, name));
                return;
            }

            Initialize();

            OutputWriter.WriteOneLineMessage("Reading data...");

            string[] input = File.ReadAllLines(path);
            for (int i = 0; i < input.Length; i++)
            {
                ProcessingInput(input[i]);
            }

            OutputWriter.WriteOneLineMessage("Data read!");
        }

        //Input format – {Course Name}_{Course Instance}{One or more white spaces}{Username}{One or more white spaces}{Score}
        private static void ProcessingInput(string input)
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

        private static bool IsQueryForCoursePossible(string courseName)
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

        private static bool IsQueryForStudentPossiblе(string courseName, string studentName)
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

        public static List<int> GetStudent(string courseName, string studentName)
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
        public static Dictionary<string, List<int>> GetAllStudents(string courseName)
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
