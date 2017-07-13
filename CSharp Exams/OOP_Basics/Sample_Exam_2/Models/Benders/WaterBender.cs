﻿using System;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; set; }

    public override double TotalPower()
    {
        return base.Power * this.WaterClarity;
    }
}
