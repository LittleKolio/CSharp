namespace Polymorphism_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_02_Vehicles_Extension
    {
        static void Main()
        {
            string[] inputCar = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(
                double.Parse(inputCar[1]),
                double.Parse(inputCar[2]),
                double.Parse(inputCar[3])
                );

            string[] inputTruck = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(
                double.Parse(inputTruck[1]),
                double.Parse(inputTruck[2]),
                double.Parse(inputTruck[3])
                );

            string[] inputBus = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(
                double.Parse(inputBus[1]),
                double.Parse(inputBus[2]),
                double.Parse(inputBus[3])
                );

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (input[1])
                    {
                        case "Car":
                            ExecuteAction(car, input[0], double.Parse(input[2]));
                            break;
                        case "Truck":
                            ExecuteAction(truck, input[0], double.Parse(input[2]));
                            break;
                        case "Bus":
                            ExecuteAction(bus, input[0], double.Parse(input[2]));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ExecuteAction(Vehicle vehicle, string command, double num)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(num));
                    break;
                case "Refuel":
                    vehicle.Refuel(num);
                    break;
                case "DriveEmpty":
                    Console.WriteLine(vehicle.Drive(num, false));
                    break;
            }
        }
    }
}
