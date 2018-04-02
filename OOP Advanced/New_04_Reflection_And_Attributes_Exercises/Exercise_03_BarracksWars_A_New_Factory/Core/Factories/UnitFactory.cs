namespace Exercise_03_BarracksWars_A_New_Factory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == unitType);

            //Type type = Type.GetType($"Exercise_03_BarracksWars_A_New_Factory.Models.Units.{unitType}");

            if (model == null)
            {
                throw new ArgumentException(
                    "Invalid unit type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new InvalidOperationException(
                    "UnitType don't inherit IUnit!");
            }

            IUnit unit = (IUnit)Activator.CreateInstance(model);
            return unit;
        }
    }
}
