using System;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        string[] carInput = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Car car = new Car(
            double.Parse(carInput[1]),
            double.Parse(carInput[2])
            );

        string[] truckInput = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Truck truck = new Truck(
            double.Parse(truckInput[1]),
            double.Parse(truckInput[2])
            );

        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (input[1])
            {
                case "Car": VehicleOperations(car, input[0], double.Parse(input[2])); break;
                case "Truck": VehicleOperations(truck, input[0], double.Parse(input[2])); break;
                default: break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static void VehicleOperations(
        Vehicle vehicle, string operation, double param)
    {
        //MethodInfo method = typeof(Vehicle).GetMethod(operation);
        //ParameterInfo[] methodParams = method.GetParameters();
        //object[] currentParams = new object[methodParams.Length];
        //for (int i = 0; i < methodParams.Length; i++)
        //{
        //    Type paramType = methodParams[i].ParameterType;
        //    currentParams[i] = Convert.ChangeType(ps[i], paramType);
        //}

        string driven = string.Empty;

        switch (operation)
        {
            case "Drive":
                {
                    try
                    {
                        vehicle.Drive(param);
                        Console.WriteLine($"{vehicle.GetType().Name} travelled {param} km");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } break;

            case "Refuel": vehicle.Refuel(param); break;

            default: break;
        }
    }
}