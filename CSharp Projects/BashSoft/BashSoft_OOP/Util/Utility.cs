namespace BashSoft_OOP.Util
{
    using StaticData;
    using System;

    public static class Utility
    {
        public static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool CheckNumberOfParameters(int expectedNum, int tokens)
        {
            if (tokens != expectedNum)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(ExceptionMessages.params_InvalidNumber, expectedNum));
            }
            return true;
        }
    }
}
