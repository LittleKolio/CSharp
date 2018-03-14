using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class Engine
{
    private CarManager carManager;
    private MethodInfo[] methods;

    public Engine()
    {
        this.carManager = new CarManager();
        this.methods = typeof(CarManager).GetMethods();
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "Cops Are Here")
        {
            string[] arguments = InputParser.SplitInput(input, " ");
            string command = arguments[0];
            arguments = arguments.Skip(1).ToArray();

            string result = string.Empty;

            switch (command)
            {
                case "register":
                    {
                        int id = int.Parse(arguments[0]);
                        string type = arguments[1];
                        string brand = arguments[2];
                        string model = arguments[3];
                        int yearOfProduction = int.Parse(arguments[4]);
                        int horsepower = int.Parse(arguments[5]);
                        int acceleration = int.Parse(arguments[6]);
                        int suspension = int.Parse(arguments[7]);
                        int durability = int.Parse(arguments[8]);
                        this.carManager.Register(
                            id, type, brand, model, yearOfProduction, horsepower, 
                            acceleration, suspension, durability);
                    }
                    break;

                case "check":
                    {
                        int id = int.Parse(arguments[0]);
                        result = this.carManager.Check(id);
                    }
                    break;

                case "open":
                    {
                        int id = int.Parse(arguments[0]);
                        string type = arguments[1];
                        int length = int.Parse(arguments[2]);
                        string route = arguments[3];
                        int prizePool = int.Parse(arguments[4]);
                        this.carManager.Open(id, type, length, route, prizePool);
                    }
                    break;

                case "participate":
                    {
                        int carId = int.Parse(arguments[0]);
                        int raceId = int.Parse(arguments[1]);
                        this.carManager.Participate(carId, raceId);
                    }
                    break;

                case "start":
                    {
                        int raceId = int.Parse(arguments[0]);
                        result = this.carManager.Start(raceId);
                    }
                    break;

                case "park":
                    {
                        int carId = int.Parse(arguments[0]);
                        this.carManager.Park(carId);
                    }
                    break;

                case "unpark":
                    {
                        int carId = int.Parse(arguments[0]);
                        this.carManager.Unpark(carId);
                    }
                    break;

                case "tune":
                    {
                        int tuneIndex = int.Parse(arguments[0]);
                        string tuneAddOn = arguments[1];
                        this.carManager.Tune(tuneIndex, tuneAddOn);
                    }
                    break;

                default:
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }

    private object[] MethodParameters(string methodName, string[] arguments)
    {
        ParameterInfo[] parameters = this.methods
            .FirstOrDefault(m => m.Name == methodName)
            .GetParameters();

        object[] currentParameters = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type parameter = parameters[i].ParameterType;
            currentParameters[i] = Convert.ChangeType(arguments[i], parameter);
        }

        return currentParameters;
    }
}