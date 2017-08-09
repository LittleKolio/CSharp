namespace Reflection_Exercises
{
    using System;

    public class UnitFactory : IUnitFactory
    {
        private const string unitNameSpace = "Reflection_Exercises";
        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(unitNameSpace + "." + unitType);
            IUnit unit = (IUnit)Activator.CreateInstance(typeUnit);
            return unit;
        }
    }
}
