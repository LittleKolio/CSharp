namespace Exercise_08_Pet_Clinics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine
    {
        private List<Clinic> clinics;
        private List<Pet> pets;

        public Engine()
        {
            this.clinics = new List<Clinic>();
            this.pets = new List<Pet>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {

                string[] tokens = this.SplitInput(Console.ReadLine(), " ");

                string result = string.Empty;

                try
                {
                    result = this.CommadSwitcher(tokens);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }


        }

        private string CommadSwitcher(string[] tokens)
        {
            string cmd = tokens[0];
            tokens = tokens.Skip(1).ToArray();

            string result = string.Empty;

            switch (cmd)
            {
                case "Create":
                    this.CreateSwitcher(tokens);
                    break;

                case "Add":
                    {
                        string petName = tokens[0];
                        string clinicName = tokens[1];

                        Pet pet = this.pets
                            .FirstOrDefault(p => p.Name == petName);
                        Clinic clinic = this.clinics
                            .FirstOrDefault(c => c.Name == clinicName);

                        if (clinic != null)
                        {
                            result = clinic.Add(pet).ToString();
                        }
                    }
                    break;

                case "Release":
                    {
                        string name = tokens[0];

                        Clinic clinic = this.clinics
                            .FirstOrDefault(c => c.Name == name);

                        if (clinic != null)
                        {
                            result = clinic.Release().ToString();
                        }
                    }
                    break;

                case "HasEmptyRooms":
                    {
                        string name = tokens[0];

                        Clinic clinic = this.clinics
                            .FirstOrDefault(c => c.Name == name);

                        if (clinic != null)
                        {
                            result = clinic.HasEmptyRooms().ToString();
                        }
                    }
                    break;

                case "Print":
                    {
                        string name = tokens[0];

                        Clinic clinic = this.clinics
                            .FirstOrDefault(c => c.Name == name);

                        if (clinic != null)
                        {
                            if (tokens.Length == 2)
                            {
                                int room = int.Parse(tokens[1]);
                                clinic.Print(room);
                            }
                            else
                            {
                                clinic.Print();
                            }
                        }

                    }
                    break;

                default:
                    throw new ArgumentException(
                        "Invalid command!");
            }

            return result;
        }

        private void CreateSwitcher(string[] tokens)
        {
            string cmd = tokens[0];
            tokens = tokens.Skip(1).ToArray();

            switch (cmd)
            {
                case "Pet":
                    {
                        string name = tokens[0];
                        int age = int.Parse(tokens[1]);
                        string kind = tokens[2];

                        this.pets.Add(new Pet(name, age, kind));
                    }
                    break;

                case "Clinic":
                    {
                        string name = tokens[0];
                        int rooms = int.Parse(tokens[1]);

                        this.clinics.Add(new Clinic(name, rooms));
                    }
                    break;

                default:
                    throw new ArgumentException(
                        "Invalid create command!");
            }
        }

        //private void Print(IEnumerable<Person> list)
        //{
        //    foreach (Person person in list)
        //    {
        //        Console.WriteLine(person);
        //    }
        //}

        private string[] SplitInput(string input, string delimiter)
        {
            return input.Split(delimiter.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
