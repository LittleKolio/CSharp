namespace Polymorphism_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_01_Vehicles
    {
        static void Main()
        {
            string[] inputCar = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            string[] inputTruck = Console.ReadLine()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            int count = int.Parse(Console.ReadLine());

            Car car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]));
            Truck truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]));

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                switch (input[1])
                {
                    case "Car":
                        ExecuteAction(car, input[0], double.Parse(input[2]));
                        break;
                    case "Truck":
                        ExecuteAction(truck, input[0], double.Parse(input[2]));
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
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
            }
        }
    }
}
