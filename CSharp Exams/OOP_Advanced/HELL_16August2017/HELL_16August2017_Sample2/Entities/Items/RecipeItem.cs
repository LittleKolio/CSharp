using System;
using System.Collections.Generic;

public class RecipeItem : IRecipe
{
    private List<string> requiredItems;

    public RecipeItem(
    string name,
    int strengthBonus,
    int agilityBonus,
    int intelligenceBonus,
    int hitpointsBonus,
    int damageBonus)
    {
        this.requiredItems = new List<string>();
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitpointsBonus;
        this.DamageBonus = damageBonus;
    }

    public List<string> RequiredItems
    {
        get { return this.requiredItems; }
    }

    public int AgilityBonus { get; private set; }

    public int DamageBonus { get; private set; }

    public int HitPointsBonus { get; private set; }

    public int IntelligenceBonus { get; private set; }

    public string Name { get; private set; }

    public int StrengthBonus { get; private set; }
}