using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.dropoutDrivers = new Stack<Driver>();

        this.driverFactory = new DriverFactory();
        this.carFactory = new CarFactory();
        this.tyreFactory = new TyreFactory();

        this.weather = "Sunny";
    }

    public List<Driver> drivers;
    public Stack<Driver> dropoutDrivers;

    private Track track;
    private DriverFactory driverFactory;
    private CarFactory carFactory;
    private TyreFactory tyreFactory;

    private string weather;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        List<string> driverArgs = commandArgs.Take(2).ToList();
        List<string> carArgs = commandArgs.Skip(2).Take(2).ToList();
        List<string> tyreArgs = commandArgs.Skip(4).ToList();

        Tyre tyre = this.tyreFactory.GetTyre(tyreArgs);
        if (tyre == null)
        {
            return;
        }

        Car car = this.carFactory.GetCar(carArgs, tyre);
        if (car == null)
        {
            return;
        }

        Driver driver = this.driverFactory.GetDriver(driverArgs, car);
        if (driver == null)
        {
            return;
        }

        this.drivers.Add(driver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string command = commandArgs[0];

        Driver driver = this.drivers
            .FirstOrDefault(d => d.Name == commandArgs[1]);

        if (driver != null)
        {
            driver.TotalTime += 20;
            switch (command)
            {
                case "ChangeTyres":
                    {
                        List<string> tyreArgs = commandArgs.Skip(2).ToList();
                        driver.Car.Tyre = this.tyreFactory.GetTyre(tyreArgs);
                    }
                    break;
                case "Refuel":
                    {
                        double fuel = double.Parse(commandArgs[2]);

                        driver.Car.ChangeFuelAmount(fuel);
                    }
                    break;
                default: return;
            }
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int completeLaps;
        if (!int.TryParse(commandArgs[0], out completeLaps))
        {
            return null;
        }

        if (completeLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            return $"There is no time! On lap {this.track.CurrentLap}.";
        }

        StringBuilder result = new StringBuilder();

        int trLength = this.track.TrackLength;

        for (int l = 0; l < completeLaps; l++)
        {
            this.track.CurrentLap++;

            for (int d = 0; d < this.drivers.Count; d++)
            {
                Driver currentDriver = this.drivers[d];

                currentDriver.IncreaseTotalTime(trLength);
                currentDriver.DecreaseCarFuelAmount(trLength);
                currentDriver.DecreaseTyreDegradation();

                if (!currentDriver.isRasing)
                {
                    this.dropoutDrivers.Push(currentDriver);
                    this.drivers[d] = null;
                }
            }

            this.drivers.RemoveAll(d => d == null);
            string result2 = this.Overtaking();
            result.Append(result2);
        }

        return result.ToString().TrimEnd();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder(this.track + Environment.NewLine);

        List<Driver> currentDrivers = this.drivers
            .OrderBy(d => d.TotalTime)
            .Concat(this.dropoutDrivers)
            .ToList();

        for (int i = 0; i < currentDrivers.Count; i++)
        {
            sb.AppendLine($"{i + 1} " + currentDrivers[i]);
        }

        return sb.ToString().TrimEnd(); ;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    private string Overtaking()
    {
        List<Driver> overtakingList = this.drivers
            .OrderByDescending(d => d.TotalTime)
            .ToList();

        StringBuilder sb = new StringBuilder();

        for (int d = 0; d < overtakingList.Count - 1; d++)
        {
            
            Driver behindDriver = overtakingList[d];
            Driver aheadDriver = overtakingList[d + 1];

            bool crazyDriver = behindDriver is AggressiveDriver &&
                    behindDriver.Car.Tyre is UltrasoftTyre;
            bool stupidDriver = behindDriver is EnduranceDriver &&
                    behindDriver.Car.Tyre is HardTyre;

            double interval = (crazyDriver || stupidDriver) ? 3 : 2;

            double difference = behindDriver.TotalTime - aheadDriver.TotalTime;

            if (difference <= interval)
            {
                if (interval == 3)
                {
                    if ((crazyDriver && this.weather == "Foggy") ||
                        (stupidDriver && this.weather == "Rainy"))
                    {
                        behindDriver.Crashed();
                        this.dropoutDrivers.Push(behindDriver);
                        this.drivers.Remove(behindDriver);
                        continue;
                    }
                }

                behindDriver.TotalTime -= interval;
                aheadDriver.TotalTime += interval;

                sb.AppendFormat("{0} has overtaken {1} on lap {2}." + Environment.NewLine,
                    behindDriver.Name, aheadDriver.Name, this.track.CurrentLap);
                d++;
            }
        }

        return sb.ToString().TrimEnd();
    }
}