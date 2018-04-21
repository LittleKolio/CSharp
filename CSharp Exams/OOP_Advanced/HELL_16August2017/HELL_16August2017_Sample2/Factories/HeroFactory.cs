using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HeroFactory : IHeroFactory
{
    public IHero CreateHero(IList<string> arguments)
    {
        string heroName = arguments[0];
        string heroType = arguments[1];

        Type type = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == heroType);

        if (type == null)
        {
            throw new ArgumentException(
                "Invalid HeroType!");
        }

        if (!typeof(IHero).IsAssignableFrom(type))
        {
            throw new ArgumentException(
                "HeroType don't inherit IHero!");
        }

        IHero hero = (IHero)Activator.CreateInstance(type, heroName);

        return hero;
    }
}