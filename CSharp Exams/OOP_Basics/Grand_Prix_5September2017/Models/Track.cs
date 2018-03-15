public class Track
{
    public Track(int lapsNumber, int trackLength)
    {
        this.lapsNumber = lapsNumber;
        this.trackLength = trackLength;
        this.CurrentLap = 0;
    }

    private int lapsNumber;
    private int trackLength;

    public int CurrentLap { get; set; }
    public int LapsNumber => this.lapsNumber;
    public int TrackLength => this.trackLength;

    public override string ToString()
    {
        return $"Lap {this.CurrentLap}/{this.LapsNumber}";
    }
}