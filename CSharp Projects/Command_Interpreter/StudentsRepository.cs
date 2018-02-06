namespace Command_Interpreter
{
    using IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;

        //Course name, student name, list of grades
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteOneLineMessage("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();

                isDataInitialized = true;
                OutputWriter.WriteOneLineMessage("Data read!");
            }
            else
            {
                OutputWriter.WriteOneLineMessage(
                    ExceptionMessages.data_IsInitialized);
            }
        }

        private static void ReadData()
        {
            string input;
            while (!string.IsNullOrEmpty(input = Console.ReadLine()))
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
        }
    }
}
