using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_Exam_25June2017
{
    /// <summary>
    /// Your task will be to prepare an electronic register for a hospital. In the hospital we have different departments: Cardiology, Oncology, Emergency etc.
    /// Each department has 20 rooms for patients and each room has 3 beds.
    /// If there are no free beds, the patient should go in another hospital.
    /// Each doctor can have patients in a different department.
    /// You will receive information about patients in the format {Department} {Doctor} {Patient}
    /// After the "Output" command you will receive some other commands with what kind of output you need to print.
    /// </summary>
    /// <output>
    /// {Department} – print all patients in this department in order of receiving on new line
    /// {Department} {Room} – print all patients in this room in alphabetical order each on new line
    /// {Doctor} – print all patients that are healed from doctor in alphabetical order on new line
    /// </output>
    /// <remarks>
    /// {Department} – single word with length 1 < n < 100
    /// {Doctor} – name and surname, both with length 1 < n< 20
    /// {Patient} – unique name with length 1 < n< 20
    /// {Room} – integer 1 <= n <= 20
    /// Time limit: 0.3 sec.Memory limit: 16 MB.
    /// </remarks>
    class Exam_04_Hospital
    {
        static void Main()
        {
            Dictionary<string, int> departments 
                = new Dictionary<string, int>();

            List<string[]> info = new List<string[]>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] formatInput = input
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string department = formatInput[0];
                string doctor = formatInput[1] + " " + formatInput[2];
                string patient = formatInput[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, 0);
                }


                if (departments[department] < 60)
                {
                    int patientNum = ++departments[department];
                    info.Add(new string[]
                        { department, doctor, patient, patientNum.ToString() });
                }
            }


            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] formatCommands = commands
                    .Split(new[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                if (departments.ContainsKey(formatCommands[0]))
                {
                    if (formatCommands.Length == 1)
                    {
                        info
                            .Where(e => e[0] == formatCommands[0])
                            .ToList()
                            .ForEach(e => Console.WriteLine(e[2]));
                    }
                    else
                    {
                        int room = int.Parse(formatCommands[1]);
                        info
                          .Where(e => 
                              e[0] == formatCommands[0] &&
                              (room * 3 - 2) <= int.Parse(e[3]) &&
                              int.Parse(e[3]) <= (room * 3))
                          .OrderBy(e => e[2])
                          .ToList()
                          .ForEach(e => Console.WriteLine(e[2]));

                       
                    }
                }
                else
                {
                    string doctor = formatCommands[0] + " " + formatCommands[1];
                    info
                        .Where(e => e[1] == doctor)
                        .OrderBy(e => e[2])
                        .ToList()
                        .ForEach(e => Console.WriteLine(e[2]));
                }
            }
        }
    }
}
