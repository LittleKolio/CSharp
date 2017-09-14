namespace BashSoft
{
    using IO;
    using System;
    using System.Collections.Generic;

    public static class StudentsRepository
    {
        public static bool isDataInitialize = false;
        private static Dictionary<string, Dictionary<string, List<int>>> coursesAndStudents;

        public static void InitializeData()
        {
            if (!isDataInitialize)
            {
                coursesAndStudents = new Dictionary<string, Dictionary<string, List<int>>>();
            }
            else
            {
                OutputWriter.WriteOneLineMessage(CustomMessages.dataExists);
            }
        }

        public static void ReadData()
        {
            string input;
            while (!string.IsNullOrEmpty(
                input = Console.ReadLine()))
            {
                string[] tokens = input.Split(
                    new[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                string cours = tokens[0];
                string student = tokens[1];
                int mark = int.Parse(tokens[2]);

                if (!coursesAndStudents.ContainsKey(cours))
                {
                    coursesAndStudents.Add(cours, new Dictionary<string, List<int>>());
                }

                if (!coursesAndStudents[cours].ContainsKey(student))
                {
                    coursesAndStudents[cours].Add(student, new List<int>());
                }

                coursesAndStudents[cours][student].Add(mark);
            }

            isDataInitialize = true;
            OutputWriter.WriteOneLineMessage("Read data.");
        }

        private static void DisplayStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteOneLineMessage($"{student.Key} - {string.Join(", ", student.Value)}");
        }

        public static void GetStudentScores(string cours, string student)
        {
            if (coursesAndStudents.ContainsKey(cours) &&
                coursesAndStudents[cours].ContainsKey(student))
            {
                DisplayStudent(
                    new KeyValuePair<string, List<int>>(
                        student, coursesAndStudents[cours][student]));
            }
        }

        public static void GetCoursStudents(string cours)
        {
            if (coursesAndStudents.ContainsKey(cours))
            {
                foreach (string student in coursesAndStudents[cours].Keys)
                {
                    DisplayStudent(
                    new KeyValuePair<string, List<int>>(
                        student, coursesAndStudents[cours][student]));
                }
            }
        }
    }
}
