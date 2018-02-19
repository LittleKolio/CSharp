namespace Exercise_01_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RawData
    {
        public static List<Car> cars;
        public static void Main()
        {
            cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = SplitInput(Console.ReadLine(), " ");

                string model = tokens[0];
                Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                Cargo cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
                List<Tire> tires = new List<Tire>
                {
                    new Tire(double.Parse(tokens[5]), int.Parse(tokens[6])),
                    new Tire(double.Parse(tokens[7]), int.Parse(tokens[8])),
                    new Tire(double.Parse(tokens[9]), int.Parse(tokens[10])),
                    new Tire(double.Parse(tokens[11]), int.Parse(tokens[12]))
                };

                cars.Add(new Car(model, engine, cargo, tires));
            }
            
            string command = Console.ReadLine();

            Func<Car, bool> func = SwitchFunc(command);

            PrintResult(func);
            
        }

        private static void PrintResult(Func<Car, bool> func)
        {
            cars
                .Where(func)
                .ToList()
                .ForEach(car => Console.WriteLine(car.Model));
        }

        private static Func<Car, bool> SwitchFunc(string command)
        {
            switch (command)
            {
                case "fragile": return car => car.Cargo.Type == "fragile" &&
                    car.Tires.Any(tire => tire.Pressure < 1);
                case "flamable": return car => car.Cargo.Type == "flamable" &&
                    car.Engine.Power > 250;
                default: return null;
            }
        }

        private static string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
