namespace Events_Exercises.Exercises_04
{
    using System;

    public class Job
    {
        public event EventHandler JobDone;

        public Job(string name, int hours, Employee employee)
        {
            this.HoursOfWorkRequired = hours;
            this.Name = name;
            this.Employee = employee;
        }

        public string Name { get; private set; }
        public int HoursOfWorkRequired  { get; private set; }
        public Employee Employee { get; set; }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;

            if (this.HoursOfWorkRequired <= 0)
            {
                if (this.JobDone != null)
                {
                    this.JobDone(this, new EventArgs());
                }
            }
        }

        public void OnJobDone(object sender, EventArgs ev)
        {
            Console.WriteLine($"Job {this.Name} done!");
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}
