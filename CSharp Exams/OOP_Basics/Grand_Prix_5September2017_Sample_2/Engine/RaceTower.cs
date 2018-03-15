using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class RaceTower
{
    public List<Driver> drivers;
    public List<Driver> dropoutDrivers;
    private DriverFactory driverFactory;
    private CarFactory carFactory;
    private TyreFactory tyreFactory;


    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.dropoutDrivers = new List<Driver>();
        this.driverFactory = new DriverFactory();
        this.carFactory = new CarFactory();
        this.tyreFactory = new TyreFactory();
        this.CurrentLap = 0;
        this.Weather = "Sunny";
    }

    public string Weather { get; private set; }
    public int DropOutIndex { get; private set; }
    public int LapsNumber { get; private set; }
    public int TrackLength { get; private set; }
    public int CurrentLap { get; private set; }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }


    //args 0_{type} 1_{name} 2_{hp} 3_{fuelAmount} 4_{tyreType} 5_{tyreHardness}
    //args 0_{type} 1_{name} 2_{hp} 3_{fuelAmount} 4_Ultrasoft  5_{tyreHardness} 6_{grip}
    public void RegisterDriver(List<string> args)
    {
        List<string> driverArgs = args.Take(2).ToList();
        List<string> carArgs = args.Skip(2).Take(2).ToList();
        List<string> tyreArgs = args.Skip(4).ToList();

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

    public void DriverBoxes(List<string> args)
    {
        string command = args[0];
        string name = args[1];
        Driver driver = this.drivers.Find(d => d.Name == name);
        driver.TotalTime += 20;
        switch (command)
        {
            case "ChangeTyres":
                {
                    List<string> tyreArgs = args.Skip(2).ToList();
                    driver.Car.Tyre = this.tyreFactory.GetTyre(tyreArgs);
                } break;
            case "Refuel":
                {
                    double fuel = double.Parse(args[2]);

                    driver.Car.FuelAmount += fuel;
                }
                break;
            default:
                break;
        }
    }

    public string CompleteLaps(List<string> args)
    {
        if (this.DropOutIndex == default(int))
        {
            this.DropOutIndex = this.drivers.Count - 1;
        }

        int completeLaps = int.Parse(args[0]);
        if (completeLaps > this.LapsNumber - this.CurrentLap)
        {
            throw new Exception(
                $"There is no time! On lap {this.CurrentLap}.");
        }

        StringBuilder result = new StringBuilder();

        for (int l = 0; l < completeLaps; l++)
        {
            this.CurrentLap++;

            for (int d = 0; d < this.drivers.Count; d++)
            {
                Driver currentDriver = this.drivers[d];

                currentDriver.IncreaseTotalTime(this.TrackLength);

                try
                {
                    currentDriver.DecreaseFuelAmount(this.TrackLength);
                }
                catch (Exception ex)
                {
                    currentDriver.failureReason = ex.Message;
                    this.dropoutDrivers.Add(currentDriver);
                    this.drivers.RemoveAt(d);
                    d--;
                    continue;
                }

                try
                {
                    currentDriver.Car.Tyre.DecreaseDegradation();
                }
                catch (Exception ex)
                {
                    currentDriver.failureReason = ex.Message;
                    this.dropoutDrivers.Add(currentDriver);
                    this.drivers.RemoveAt(d);
                    d--;
                    continue;
                }
            }

            result.Append(this.Overtaking());
        }

        return result.ToString().TrimEnd();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.CurrentLap}/{this.LapsNumber}");

        for (int i = 0; i < this.drivers.Count; i++)
        {
            int position = i + 1;
            string name = this.drivers[i].Name;
            double time = this.drivers[i].TotalTime;

            sb.AppendLine($"{position} {name} {time:F3}");
        }

        for (int i = this.dropoutDrivers.Count - 1; i >= 0; i--)
        {
            int position = this.dropoutDrivers.Count - i + this.drivers.Count;
            string name = this.dropoutDrivers[i].Name;
            string failure = this.dropoutDrivers[i].failureReason;

            sb.AppendLine($"{position} {name} {failure}");
        }

        return sb.ToString().TrimEnd(); ;
    }

    public void ChangeWeather(List<string> args)
    {
        this.Weather = args[0];
    }

    private string Overtaking()
    {
        StringBuilder sb = new StringBuilder();

        for (int d = this.drivers.Count - 1; d >= 1; d--)
        {
            double interval = 2;
            Driver behindDriver = this.drivers[d];
            Driver aheadDriver = this.drivers[d - 1];

            double difference = behindDriver.TotalTime - aheadDriver.TotalTime;

            if (behindDriver.GetType().Name == "AggressiveDriver" && 
                behindDriver.Car.Tyre.GetType().Name == "UltrasoftTyre")
            {
                if (this.Weather == "Foggy")
                {
                    behindDriver.failureReason = "Crashed";
                    this.dropoutDrivers.Add(behindDriver);
                    this.drivers.RemoveAt(d);
                    d++;
                }
                interval = 3;
            }

            if (behindDriver.GetType().Name == "EnduranceDriver" &&
                behindDriver.Car.Tyre.GetType().Name == "HardTyre")
            {
                if (this.Weather == "Rainy")
                {
                    behindDriver.failureReason = "Crashed";
                    this.dropoutDrivers.Add(behindDriver);
                    this.drivers.RemoveAt(d);
                    d++;
                }
                interval = 3;
            }

            if (difference <= interval)
            {
                if (difference >= 0)
                {
                    behindDriver.TotalTime -= interval;
                    aheadDriver.TotalTime += interval;
                }
                this.drivers.RemoveAt(d);
                this.drivers.Insert(d - 1, behindDriver);

                sb.AppendFormat("{0} has overtaken {1} on lap {2}." + Environment.NewLine,
                    behindDriver.Name, aheadDriver.Name, this.CurrentLap);

                //reset Overtaking
                d = this.drivers.Count;
            }
        }

        return sb.ToString();
    }
}