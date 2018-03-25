namespace Logger
{
    public static class Constants
    {
        /// <summary>
        /// Format: {0_date-time} - {1_report level} - {2_message}
        /// </summary>
        public const string format_1 = "{0} - {1} - {2}";

        public const string dateTimeFormat = "M/d/yyyy h:mm:ss tt";

        public const string AppenderToString = "Appender type: {0}, Layout type: {1}, Report level: {2}, Messages appended: {3}";

        public const string LogFileToString = AppenderToString + ", File size {4}";
    }
}