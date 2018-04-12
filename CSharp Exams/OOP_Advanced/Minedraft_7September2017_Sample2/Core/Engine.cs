using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager manager;

    public Engine()
    {
        this.manager = new DraftManager();
    }

    public void Run()
    {
        while (true)
        {
            List<string> data = Console.ReadLine().Split().ToList();
            string command = data[0];

            switch (command)
            {
                case "Register":
                    {
                        string type = data[1];
                        List<string> args = data.Skip(2).ToList();
                        if (type == "Harvester")
                        {
                            manager.RegisterHarvester(args);
                        }
                        else if (type == "Provider")
                        {
                            manager.RegisterProvider(args);
                        }
                    }
                    break;

                //case "RegisterProvider":
                //    manager.RegisterProvider(args);
                //    break;

                case "Day": manager.Day(); break;

                case "Mode":
                    {
                        List<string> args = data.Skip(1).ToList();
                        manager.Mode(args);
                    }
                    break;

                case "Check":
                    //Console.WriteLine(manager.Check(args));
                    break;

                default:
                    manager.ShutDown();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
