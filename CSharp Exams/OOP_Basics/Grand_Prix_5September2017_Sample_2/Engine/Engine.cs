using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public Engine()
    {
        this.RaceTower = new RaceTower();
    }

    public RaceTower RaceTower { get; private set; }

    private void InitialiseTrack()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        this.RaceTower.SetTrackInfo(lapsNumber, trackLength);
    }

    public void Run()
    {
        InitialiseTrack();

        string input;
        while (!string.IsNullOrEmpty(input = Console.ReadLine()))
        {
            List<string> args = InputParser.SplitInput(input, " ");
            string commsnd = args[0];
            args = args.Skip(1).ToList();

            switch (commsnd)
            {
                case "RegisterDriver": this.RaceTower.RegisterDriver(args); break;
                case "Leaderboard":
                    {
                        string result = this.RaceTower.GetLeaderboard();
                        Console.WriteLine(result);
                    } break;
                case "CompleteLaps":
                    {
                        string result = string.Empty;
                        try
                        {
                            result = this.RaceTower.CompleteLaps(args);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        if (result != string.Empty)
                        {
                            Console.WriteLine(result);
                        }
                    } break;
                case "Box": this.RaceTower.DriverBoxes(args); break;
                case "ChangeWeather": this.RaceTower.ChangeWeather(args); break;
                default:
                    break;
            }
        }

        Driver winner = this.RaceTower.drivers.First();
        Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
    }
}