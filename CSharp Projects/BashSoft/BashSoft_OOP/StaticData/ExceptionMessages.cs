namespace BashSoft_OOP
{
    public static class ExceptionMessages
    {
        public const string data_IsInitialized = "Data structure is already initialized!";
        public const string data_IsNotInitialized = "The data structure must be initialized first.";
        public const string data_Cours_NotExist = "Course: \"{0}\" does not exist in the data base!";
        public const string data_Filter_Invalid = "Filter is not one of the following: excellent/average/poor";
        public const string data_Order_Invalid = "Order is not one of the following: ascending/descending";
        public const string data_Student_Requirements = "No student meets the requirements.";
        public const string data_Student_InCourse = "Student: \"{0}\" already exists in course: \"{1}\".";
        public const string data_Student_NotInCourse = "Student: \"{0}\" does not exist in this course: \"{1}\".";
        public const string data_Student_InvalidScores = "Student: \"{0}\" has invalid scores.";

        public const string file_DoseNotExist = "File: \"{0}\" does not exist!";
        public const string file_DontHaveAccess = "You don't have access to tose file!";
        public const string file_ForbiddenSymbols = "File name contains not allowed symbols.";
        public const string file_WriteMismatche = "Line {0} -- expected: \"{1}\", actual: \"{2}\"";


        public const string dir_DoseNotExist = "Folder does not exist!";
        public const string dir_DontHaveAccess = "You don't have access to tose folder!";
        public const string dir_ForbiddenSymbols = "Folder name contains not allowed symbols.";

        public const string params_InvalidNumber = "Expect {0} parameters.";
        public const string params_InvalidParameter = "The parameter: \"{0}\" is invalid.";

        public const string command_Null = "Insert command.";
    }
}
