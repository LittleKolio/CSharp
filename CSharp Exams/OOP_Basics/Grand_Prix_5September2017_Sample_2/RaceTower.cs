using System;
using System.Linq;
using System.Collections.Generic;

public class RaceTower
{
    public List<Driver> Drivers { get; set; }
    public int LapsNumber { get; set; }
    public int TrackLength { get; set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }

    public string GetLeaderboard()
    {
        //TODO: Add some logic here …
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        //TODO: Add some logic here …
    }


}