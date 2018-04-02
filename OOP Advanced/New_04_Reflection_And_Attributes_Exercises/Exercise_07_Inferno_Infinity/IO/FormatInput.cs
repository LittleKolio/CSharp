namespace Exercise_07_Inferno_Infinity.IO
{
    using System;
    using Contracts;

    public class FormatInput : IFormat
    {
        public string[] Format(string input, string delimiter)
        {
            string[] result = input
                .Split(
                    delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries
                );

            return result;
        }
    }
}
