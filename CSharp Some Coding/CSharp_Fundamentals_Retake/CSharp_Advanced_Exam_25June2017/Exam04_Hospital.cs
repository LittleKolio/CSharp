namespace Trash.CSharp_Advanced_Exam_25June2017
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Exam04_Hospital
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
                //Department - Doctor - Patient
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
