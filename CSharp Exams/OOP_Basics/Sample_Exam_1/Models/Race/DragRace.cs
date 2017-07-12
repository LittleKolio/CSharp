using System;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    { }

    public override int Points(Car car)
    {
        return car.Horsepower / car.Acceleration;
    }
}
