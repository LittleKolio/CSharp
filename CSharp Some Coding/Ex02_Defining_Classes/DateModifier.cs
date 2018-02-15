using System;
using System.Globalization;

public class DateModifier
{
    private const string format = "yyyy MM dd";
    private double days;

    public double Days
    {
        get { return this.days; }
        set { this.days = value; }
    }

    public void CalculateDifference(string date1, string date2)
    {
        DateTime someDate1 = DateTime.ParseExact(date1, format, CultureInfo.InvariantCulture);
        DateTime someDate2 = DateTime.ParseExact(date2, format, CultureInfo.InvariantCulture);
        this.Days = Math.Abs((someDate1 - someDate2).TotalDays);
    }
}
