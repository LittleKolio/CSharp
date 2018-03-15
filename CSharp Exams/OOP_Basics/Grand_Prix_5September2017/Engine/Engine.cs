﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    public Engine()
    {
        this.inputReader = new ConsoleReader();
        this.outputWriter = new ConsoleWriter();
    }

    private ConsoleReader inputReader;
    private ConsoleWriter outputWriter;
    private RaceTower raceTower;

    private void InitialiseTrack()
    {
        int lapsNumber = int.Parse(this.inputReader.ReadLine());
        int trackLength = int.Parse(this.inputReader.ReadLine());

        this.raceTower.SetTrackInfo(lapsNumber, trackLength);
    }

    public void Run()
    {
        InitialiseTrack();

        string input;
        while (!string.IsNullOrEmpty(input = this.inputReader.ReadLine()))
        {
            List<string> commandArgs = InputParser.SplitInput(input, " ");
            string commsnd = commandArgs[0];
            commandArgs = commandArgs.Skip(1).ToList();

            switch (commsnd)
            {
                case "RegisterDriver": this.raceTower.RegisterDriver(commandArgs); break;
                case "Leaderboard":
                    {
                        string result = this.raceTower.GetLeaderboard();
                        Console.WriteLine(result);
                    } break;
                case "CompleteLaps":
                    {
                        string result = string.Empty;
                        try
                        {
                            result = this.raceTower.CompleteLaps(commandArgs);
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
                case "Box": this.raceTower.DriverBoxes(commandArgs); break;
                case "ChangeWeather": this.raceTower.ChangeWeather(commandArgs); break;
                default:
                    break;
            }
        }

        //Driver winner = this.raceTower.drivers.First();
        //Console.WriteLine($"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.");
    }
}