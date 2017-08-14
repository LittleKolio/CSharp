namespace Events_Exercises.Exercises_04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Employee
    {
        public Employee(string name, int hours)
        {
            this.Name = name;
            this.WorkHoursPerWeek = hours;
        }

        public int WorkHoursPerWeek { get; private set; }
        public string Name { get; private set; }
    }
}
