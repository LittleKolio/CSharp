namespace Defining_Classes_Exercises.StartUp
{
    using Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_08_Raw_Data
    {
        static void Main()
        {
            List<CourierCar> list = new List<CourierCar>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(line[1]), int.Parse(line[2]));
                Cargo cargo = new Cargo(int.Parse(line[3]), line[4]);
                List<Tire> tires = new List<Tire>();
                for (int j = 5; j < line.Length; j += 2)
                {
                    tires.Add(new Tire(double.Parse(line[j]), int.Parse(line[j + 1])));
                }

                CourierCar car = new CourierCar(line[0], engine, cargo, tires);

                list.Add(car);
            }

            string type = Console.ReadLine();
            List<CourierCar> tempList = list
                .Where(car => car.Cargo.Type == type)
                .ToList();
            switch (type)
            {
                case "fragile":
                    tempList.Where(car => car.Tires.Any(tire => tire.Pressure < 1))
                        .ToList()
                        .ForEach(car => Console.WriteLine(car.Model));
                    break;

                case "flamable":
                    tempList.Where(car => car.Engine.Power > 250)
                        .ToList()
                        .ForEach(car => Console.WriteLine(car.Model));
                    break;

                default:
                    break;
            }
        }
    }
}
