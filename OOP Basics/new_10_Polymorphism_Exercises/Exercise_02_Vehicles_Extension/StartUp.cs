using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Vehicle> vehicles 
            = new Dictionary<string, Vehicle>();

        for (int i = 0; i < 3; i++)
        {
            Vehicle vehicle = VehikleFactory(
                SplitInput(Console.ReadLine(), " "));
            vehicles.Add(vehicle.GetType().Name, vehicle);
        }

        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            string[] input = SplitInput(Console.ReadLine(), " ");

            if (!vehicles.ContainsKey(input[1]))
            {
                Console.WriteLine("This vehicle don't exist!");
                return;
            }

            Vehicle vehicle = vehicles[input[1]];
            try
            {
                VehicleOperations(vehicle, input[0], double.Parse(input[2]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (KeyValuePair<string, Vehicle> vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Value);
        }
    }

    private static void VehicleOperations(
        Vehicle vehicle, string operation, double param)
    {
        switch (operation)
        {
            case "DriveEmpty":
                {
                    Bus bus = default(Bus);
                    if (vehicle.GetType().Name == "Bus")
                    {
                        bus = (Bus)vehicle;
                        bus.people = false;
                        bus.Drive(param);
                        Console.WriteLine($"Bus travelled {param} km");
                        bus.people = true;
                    }
                    else
                    {
                        Console.WriteLine("Vehicle supposed to be bus!");
                    }
                }
                break;

            case "Drive":
                {
                    vehicle.Drive(param);
                    Console.WriteLine($"{vehicle.GetType().Name} travelled {param} km");
                }
                break;

            case "Refuel": vehicle.Refuel(param); break;

            default: break;
        }
    }

    private static string[] SplitInput(string input, string delimiter)
    {
        return input.Split(delimiter.ToCharArray(),
            StringSplitOptions.RemoveEmptyEntries);
    }

    private static Vehicle VehikleFactory(string[] input)
    {
        Type vehicleType = Type.GetType(input[0]);

        ParameterInfo[] vehicleParameters = vehicleType
            .GetConstructors()
            .FirstOrDefault()
            .GetParameters();
        object[] currentParameters = new object[vehicleParameters.Length];
        try
        {
            for (int i = 0; i < vehicleParameters.Length; i++)
            {
                Type paramType = vehicleParameters[i].ParameterType;
                currentParameters[i] = Convert.ChangeType(input[i + 1], paramType);
            }
        }
        catch
        {
            Console.WriteLine("Something is wrong!");
            Console.WriteLine("Current parameters: " + string.Join("/", input));
            Console.WriteLine("Expected parameters: " + string.Join("/", vehicleParameters.Select(v => v.Name)));
        }

        Vehicle vehicle = default(Vehicle);

        try
        {
            vehicle = (Vehicle)Activator.CreateInstance(vehicleType, currentParameters);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return vehicle;
    }
}