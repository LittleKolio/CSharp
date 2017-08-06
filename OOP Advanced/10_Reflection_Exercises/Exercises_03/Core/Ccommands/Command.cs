namespace Reflection_Exercises
{
    using System;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;
        public Command(
            string[] data, 
            IRepository repository, 
            IUnitFactory unitFactory
            )
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }
        public string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }
        public IRepository Repository
        {
            get { return this.repository; }
            set { this.repository = value; }
        }
        public IUnitFactory UnitFactory
        {
            get { return this.unitFactory; }
            set { this.unitFactory = value; }
        }
        public abstract string Execute();
    }
}