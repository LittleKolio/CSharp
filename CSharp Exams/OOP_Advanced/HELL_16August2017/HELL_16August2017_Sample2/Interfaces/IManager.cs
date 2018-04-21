using System.Collections.Generic;

public interface IManager
{
    IReadOnlyDictionary<string, IHero> Heroes { get; }

    string AddHero(List<string> arguments);
}