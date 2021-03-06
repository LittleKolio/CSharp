﻿using System;

public class CommonItem : IItem
{
    public CommonItem(
    string name,
    int strengthBonus,
    int agilityBonus,
    int intelligenceBonus,
    int hitpointsBonus,
    int damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitpointsBonus;
        this.DamageBonus = damageBonus;
    }

    public int AgilityBonus { get; private set; }

    public int DamageBonus { get; private set; }

    public int HitPointsBonus { get; private set; }

    public int IntelligenceBonus { get; private set; }

    public string Name { get; private set; }

    public int StrengthBonus { get; private set; }
}