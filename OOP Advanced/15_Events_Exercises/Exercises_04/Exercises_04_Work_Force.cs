using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_Exercises.Exercises_04
{
    public class Exercises_04_Work_Force
    {
        public static void Main()
        {
            JobsList jobs = new JobsList();
            List<Employee> employees = new List<Employee>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Job":
                        Job tempJob = new Job(
                            tokens[1],
                            int.Parse(tokens[2]),
                            employees.FirstOrDefault(e => e.Name == tokens[3])
                            );
                        tempJob.JobDone += tempJob.OnJobDone;
                        //tempJob.JobDone += jobs.OnJobDone;
                        jobs.Add(tempJob);
                        break;
                    case "StandartEmployee":
                        employees.Add(
                            new StandartEmployee(tokens[1])
                            );
                        break;
                    case "PartTimeEmployee":
                        employees.Add(
                          new PartTimeEmployee(tokens[1])
                          );
                        break;
                    case "Pass":
                        foreach (Job job in jobs)
                        {
                            job.Update();
                        }
                        break;
                    case "Status":
                        foreach (Job job in jobs)
                        {
                            Console.WriteLine(job);
                        }
                        break;
                }
            }
        }
    }
}
