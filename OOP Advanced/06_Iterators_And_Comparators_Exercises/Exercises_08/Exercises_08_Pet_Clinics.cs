namespace Iterators_And_Comparators_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Exercises_08_Pet_Clinics
    {
        private static Dictionary<string, Pet> pets;
        private static Dictionary<string, Clinic> clinics;

        static void Main()
        {
            pets = new Dictionary<string, Pet>();
            clinics = new Dictionary<string, Clinic>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string cmd = input[0];
                input.Remove(cmd);

                switch (cmd)
                {
                    case "Create":
                        CreateEntity(input);
                        break;
                    case "Add":
                        AddPetToClinic(input[0], input[1]);
                        break;
                    case "Release":
                        RemovePetFromClinic(input[0]);
                        break;
                    case "HasEmptyRooms":
                        CheckForEmptyRoom(input[0]);
                        break;
                    case "Print":
                        PrintClinicInfo(input);
                        break;
                }
            }
        }

        private static void PrintClinicInfo(List<string> input)
        {
            Clinic currentClinic = clinics[input[0]];
            string result;
            if (input.Count == 1)
            {
                result = currentClinic.Print();
            }
            else
            {
                int roomIndex = int.Parse(input[1]) - 1;
                result = currentClinic.Print(roomIndex);
            }
            Console.WriteLine(result);
        }

        private static void CheckForEmptyRoom(string clinicName)
        {
            Clinic currentClinic = clinics[clinicName];
            Console.WriteLine(currentClinic.EmptyRoom());
        }

        private static void RemovePetFromClinic(string clinicName)
        {
            Clinic currentClinic = clinics[clinicName];
            Console.WriteLine(currentClinic.RemoveFirstPet());
        }

        private static void AddPetToClinic(string petName, string clinicName)
        {
            Clinic currentClinic = clinics[clinicName];
            Pet currentPet = pets[petName];
            if (currentClinic.AddPet(currentPet))
            {
                Console.WriteLine(true);
                pets.Remove(petName);
                return;
            }
            Console.WriteLine(false);
        }

        private static void CreateEntity(List<string> input)
        {
            string type = input[0];

            if (type == "Pet")
            {
                pets.Add(input[1], new Pet(
                    input[1], int.Parse(input[2]), input[3]));
            }
            else if (type == "Clinic")
            {
                try
                {
                    clinics.Add(input[1], new Clinic(
                    input[1], int.Parse(input[2])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
