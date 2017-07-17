namespace Defining_Classes_Exercises.Classes
{
    class Tire
    {
        private double pressure;
        private int age;
        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }
        public double Pressure
        {
            get { return this.pressure; }
        }
    }
}
