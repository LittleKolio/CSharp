namespace Defining_Classes_Exercises.Classes
{
    using System.Collections.Generic;

    class CourierCar
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;
        public CourierCar(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }
        public Engine Engine
        {
            get { return this.engine; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
        }
        public List<Tire> Tires
        {
            get { return this.tires; }
        }
        public string Model
        {
            get { return this.model; }
        }
    }
}
