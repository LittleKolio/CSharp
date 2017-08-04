namespace Reflection_Exercises.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string unitNameSpace = "Reflection_Exercises.Models.Units";
        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(unitNameSpace + "." + unitType);
            IUnit unit = (IUnit)Activator.CreateInstance(typeUnit);
            return unit;
        }
    }
}
