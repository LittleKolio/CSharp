using System;

public class AmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Type ammuType = Type.GetType(name);
        IAmmunition ammu = (IAmmunition)Activator.CreateInstance(
            ammuType,
            new object[] { name }
            );

        return ammu;
    }
}