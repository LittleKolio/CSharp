using System;
using System.Collections;
using System.Collections.Generic;

public class WeeklyCalendar
{
    private readonly IList<WeeklyEntry> week;
    public WeeklyCalendar()
    {
        this.week = new List<WeeklyEntry>();
    }
    public void AddEntry(string weekday, string notes)
    {
        this.week.Add(new WeeklyEntry(weekday, notes));
    }

    public IEnumerable<WeeklyEntry> WeeklySchedule
    {
        get { return this.week; }
    }
}