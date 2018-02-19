namespace BashSoft2
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        //Course name, student name, list of grades
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string path = null)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteOneLineMessage("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                if (path == null)
                {
                    ReadDataFromConsole();
                }
                else
                {
                    ReadDataFromFile(path);
                }

                isDataInitialized = true;
                OutputWriter.WriteOneLineMessage("Data read!");
            }
            else
            {
                OutputWriter.WriteOneLineMessage(
                    ExceptionMessages.data_IsInitialized);
            }
        }
        private static void ReadDataFromFile(string path)
        {
            if (!File.Exists(path))
            {
                OutputWriter.DisplayException(
                    ExceptionMessages.file_DoseNotExist);
            }

            string[] input = File.ReadAllLines(path);
            for (int i = 0; i < input.Length; i++)
            {
                ProcessingInput(input[i]);
            }
        }
        private static void ReadDataFromConsole()
        {
            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                ProcessingInput(input);
            }
        }
        private static void ProcessingInput(string input)
        {
            string[] tokens = input.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            string course = tokens[0];
            string student = tokens[1];
            int mark = int.Parse(tokens[2]);

            if (!studentsByCourse.ContainsKey(course))
            {
                studentsByCourse.Add(course,
                    new Dictionary<string, List<int>>());
            }

            if (!studentsByCourse[course].ContainsKey(student))
            {
                studentsByCourse[course].Add(student, new List<int>());
            }

            studentsByCourse[course][student].Add(mark);
        }
        private static bool IsQueryForCoursePossible(string cours)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(cours))
                {
                    return true;
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
        private static bool IsQueryForStudentPossiblе(string cours, string student)
        {
            if (IsQueryForCoursePossible(cours) &&
                studentsByCourse[cours].ContainsKey(student))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(
                    ExceptionMessages.data_StudentDoseNotExist);
            }

            return false;
        }
        public static void GetStudent(string cours, string student)
        {
            if (IsQueryForStudentPossiblе(cours, student))
            {
                OutputWriter.PrintStudent(
                    new KeyValuePair<string, List<int>>(
                        student, studentsByCourse[cours][student]));
            }
        }
        public static void GetAllStudents(string cours)
        {
            if (IsQueryForCoursePossible(cours))
            {
                OutputWriter.WriteOneLineMessage(cours);
                foreach (var student in studentsByCourse[cours])
                {
                    OutputWriter.PrintStudent(student);
                }
            }
        }
    }
}
