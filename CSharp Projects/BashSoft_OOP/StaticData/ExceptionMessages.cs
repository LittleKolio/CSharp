namespace BashSoft_OOP
{
    public static class ExceptionMessages
    {
        public const string data_IsInitialized = "Data structure is already initialized!";
        public const string data_IsNotInitialized = "The data structure must be initialized first.";
        public const string data_CoursDoseNotExist = "The course does not exist in the data base!";
        public const string data_StudentDoseNotExist = "The student does not exist in this cours!";
        public const string data_InvalidFilter = "Filter is not one of the following: excellent/average/poor";
        public const string data_InvalidOrder = "Order is not one of the following: ascending/descending";
        public const string data_NoStudent = "No student meets the requirements.";
        public const string data_AlreadyInCourse = "The {0} already exists in {1}.";
        public const string data_NotEnrolledInCourse = "Student must be enrolled in a course before you set his score.";

        public const string file_DoseNotExist = "File '{0}' does not exist!";
        public const string file_DontHaveAccess = "You don't have access to tose file!";
        public const string file_ForbiddenSymbols = "File name contains not allowed symbols.";


        public const string dir_DoseNotExist = "Folder does not exist!";
        public const string dir_DontHaveAccess = "You don't have access to tose folder!";
        public const string dir_ForbiddenSymbols = "Folder name contains not allowed symbols.";

        public const string params_InvalidNumber = "Expect {0} parameters.";
        public const string params_InvalidParameter = "The command '{0}' is invalid.";

        public const string commands_Null = "Insert command.";
    }
}
