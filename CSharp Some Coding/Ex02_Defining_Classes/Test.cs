using System;
using System.Collections.Generic;
using System.Linq;

public class Test
{
    public static Family family;
    public static void Main()
    {
        //Family();

        //DateModifier();

        //CompanyRoster();

        //SpeedRacing();

        //RawData();

        RectangleIntersection();
    }

    private static void RectangleIntersection()
    {
        List<Rectangle> list = new List<Rectangle>();

        int[] input = Console.ReadLine()
                .Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        for (int i = 0; i < input[0]; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Rectangle rec = new Rectangle(
                tokens[0],
                long.Parse(tokens[1]),
                long.Parse(tokens[2]),
                long.Parse(tokens[3]),
                long.Parse(tokens[4])
                );
            list.Add(rec);
        }

        for (int i = 0; i < input[1]; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Rectangle rec1 = list.First(r => r.Id == tokens[0]);
            Rectangle rec2 = list.First(r => r.Id == tokens[1]);
            bool result = rec1.Intersect(rec2);
            Console.WriteLine(result.ToString().ToLower());
        }
    }

    private static void RawData()
    {
        List<Carr> cars = new List<Carr>();

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Engine engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
            Cargo cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
            List<Tire> tires = new List<Tire>
                {
                    new Tire(double.Parse(tokens[5]), int.Parse(tokens[6])),
                    new Tire(double.Parse(tokens[7]), int.Parse(tokens[8])),
                    new Tire(double.Parse(tokens[9]), int.Parse(tokens[10])),
                    new Tire(double.Parse(tokens[11]), int.Parse(tokens[12]))
                };
            Carr car = new Carr(tokens[0], engine, cargo, tires);
            cars.Add(car);
        }

        string input = Console.ReadLine();
        switch (input)
        {
            case "fragile":
                cars.Where(car => car.Cargo.Type == input)
                    .Where(car => car.Tires.Any(tire => tire.Pressure < 1))
                    .ToList()
                    .ForEach(car => Console.WriteLine(car.Model));
                    break;

            case "flamable":
                cars.Where(car => car.Cargo.Type == input)
                    .Where(car => car.Engine.Power > 250)
                    .ToList()
                    .ForEach(car => Console.WriteLine(car.Model));
                break;

            default:
                break;
        }
    }

    private static void SpeedRacing()
    {
        List<Car> cars = new List<Car>();

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car(
                tokens[0],
                double.Parse(tokens[1]),
                double.Parse(tokens[2])
                );

            cars.Add(car);
        }
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            try
            {
                cars
                    .FirstOrDefault(c => c.Model == tokens[1])
                    .Drive(double.Parse(tokens[2]));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }

    private static void CompanyRoster()
    {
        List<Employee> list = new List<Employee>();

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Employee employee = new Employee(
                tokens[0],
                decimal.Parse(tokens[1]),
                tokens[2], 
                tokens[3]);

            if (tokens.Length == 5)
            {
                int age;
                if (int.TryParse(tokens[4], out age))
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = tokens[4];
                }
            }

            if (tokens.Length == 6)
            {
                employee.Email = tokens[4];
                employee.Age = int.Parse(tokens[5]);
            }

            list.Add(employee);
        }

        var result = list
            .GroupBy(e => e.Department)
            .OrderByDescending(d => d.Sum(e => e.Salary))
            .Select(d => d.OrderByDescending(e => e.Salary))
            .FirstOrDefault();

        Console.WriteLine("Highest Average Salary: " + result.FirstOrDefault().Department);

        foreach (var employee in result)
        {
            Console.WriteLine(employee);
        }

    }

    private static void Family()
    {
        family = new Family();

        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            Person person = new Person(int.Parse(tokens[1]), tokens[0]);
            family.AddMember(person);
        }

        foreach (Person person in family.GetOlderThan30Members())
        {
            Console.WriteLine(person);
        }
    }

    private static void DateModifier()
    {
        DateModifier days = new DateModifier();

        string date1 = Console.ReadLine();
        string date2 = Console.ReadLine();

        days.CalculateDifference(date1, date2);

        Console.WriteLine(days.Days);
    }
}
