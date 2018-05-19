namespace BashSoft_OOP.StaticData
{
    public static class Constants
    {
        public const string Pattern_InitializeRepository = @"([A-Z][a-zA-Z#\+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s+([\s0-9]+)$";

        public const string Command_End = "quit";

        public const string Format_ListOfCourses = "{0}{1}Course: {2} | Average: {3:00.0} ({4})";
        public const string Format_ListOfStudents = "{0}{1}Student: {2} | Average: {3:00.0} ({4})";
        public const string Format_MismatchFiles = "Line {0}{1} fileTwo: \"{2}\", fileOne: \"{3}\"";

        public const string File_IdenticalFiles = "Files are identical. There are no mismatches.";
        public const string File_MismatchFileName = "Mismatches.txt";

        public const int Padding_Name = 15;

        public const int Course_NumberOfExams = 5;
        public const int Course_MaxScoreOnExam = 100;
    }
}
