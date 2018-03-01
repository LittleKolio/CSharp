public class Repair : IRepair
{
    public string Part { get; set; }
    public int Hours { get; set; }

    public Repair(string part, int hours)
    {
        this.Part = part;
        this.Hours = hours;
    }

    public override string ToString()
    {
        return $"Part Name: {this.Part} Hours Worked: {this.Hours}";
    }
}