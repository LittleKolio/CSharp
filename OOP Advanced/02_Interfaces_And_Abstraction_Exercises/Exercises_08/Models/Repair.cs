using System;

public class Repair : IRepair
{
    public Repair(string partName, int howersWorked)
    {
        this.PartName = partName;
        this.HoursWorked = howersWorked;
    }
    public int HoursWorked { get; private set; }
    public string PartName { get; private set; }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}
