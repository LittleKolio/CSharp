using System;

public class Clinic
{
    private int roomNumber;

    public Clinic(int roomNumber)
    {
        this.RoomNumber = roomNumber;
    }

    public int RoomNumber
    {
        get { return this.roomNumber; }
        set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException(
                    "Invalid Operation!");
            }
            this.roomNumber = value;
        }
    }

}