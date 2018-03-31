using System.Globalization;

namespace Logger
{
    public class SimpleLayout : ILayout
    {
        public string CreateLogMessage(IError error)
        {
            return string.Format(Constants.format_1, 
                error.DateTime.ToString(Constants.dateTimeFormat, CultureInfo.InvariantCulture)
                , error.Level, error.Message);
        }
    }
}