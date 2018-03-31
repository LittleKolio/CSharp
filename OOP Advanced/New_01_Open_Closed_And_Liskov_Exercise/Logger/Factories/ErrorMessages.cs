using System;
using System.Globalization;

namespace Logger
{
    public class ErrorFactory
    {
        public IError CreateErrorMessages(string errorType, string dateTimeType, string message)
        {
            ErrorLevel level;
            if (!Enum.TryParse(errorType, out level))
            {
                throw new ArgumentException("Invalide Level Type!");
            }

            DateTime dateTime = DateTime.ParseExact(
                dateTimeType,
                Constants.dateTimeFormat,
                CultureInfo.InvariantCulture);

            return new Error(dateTime, message, level);
        }
    }
}
