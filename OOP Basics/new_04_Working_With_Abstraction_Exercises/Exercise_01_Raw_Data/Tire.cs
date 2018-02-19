namespace Exercise_01_Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tire
    {
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
    }
}
