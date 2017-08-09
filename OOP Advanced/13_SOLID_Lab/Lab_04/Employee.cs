namespace SOLID_Lab.Lab_04
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base (id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }
    }
}