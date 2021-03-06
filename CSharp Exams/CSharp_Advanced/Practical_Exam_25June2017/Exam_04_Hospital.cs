﻿namespace Practical_Exam_25June2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
        public static Dictionary<string, List<string>> department;
        public static Dictionary<string, List<string>> doctor;

        public static void Main()
        {
            //Department - Patient
            department = new Dictionary<string, List<string>>();

            //Doctor - Patients
            doctor = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                //Department - Doc name + surname - Patient
                string[] tokens = input.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string dep = tokens[0];
                string doc = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!department.ContainsKey(dep))
                {
                    department.Add(dep, new List<string>());
                }

                if (department[dep].Count < 60)
                {
                    department[dep].Add(patient);

                    if (!doctor.ContainsKey(doc))
                    {
                        doctor.Add(doc, new List<string>());
                    }

                    doctor[doc].Add(patient);
                }
            }

            while ((input = Console.ReadLine().Trim()) != "End")
            {
                if (department.ContainsKey(input))
                {
                    department[input]
                        .ForEach(name => Console.WriteLine(name));
                }
                else if (doctor.ContainsKey(input))
                {
                    doctor[input]
                        .OrderBy(name => name)
                        .ToList()
                        .ForEach(name => Console.WriteLine(name));
                }
                else
                {
                    string[] tokens = input.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                    string dep = tokens[0];
                    int patientIndex = (int.Parse(tokens[1]) - 1) * 3;
                    int numOfPatients = 3;

                    if ((patientIndex + 1) + numOfPatients > department[dep].Count)
                    {
                        numOfPatients = department[dep].Count - patientIndex;
                    }

                    department[dep]
                        .GetRange(patientIndex, numOfPatients)
                        .OrderBy(name => name)
                        .ToList()
                        .ForEach(name => Console.WriteLine(name));
                }
            }
        }
    }
}
