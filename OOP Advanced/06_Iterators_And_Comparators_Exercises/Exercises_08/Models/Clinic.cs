using System;
using System.Text;

public class Clinic
{
    private int roomNumber;
    private int emptyRooms;
    private RoomsRegister roomsRegister;

    public Clinic(string name, int roomNumber)
    {
        this.Name = name;
        this.RoomNumber = roomNumber;
        this.emptyRooms = roomNumber;
        this.roomsRegister = new RoomsRegister(roomNumber);
    }

    public string Name { get; private set; }

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

    public bool AddPet(Pet pet)
    {
        foreach (var roomIdex in this.roomsRegister)
        {
            if (this.roomsRegister[roomIdex] == null)
            {
                this.roomsRegister[roomIdex] = pet;
                this.emptyRooms--;
                return true;
            }
        }

        return false;
    }

    public bool RemoveFirstPet()
    {
        for (int i = 0 ; i < this.RoomNumber; i++)
        {
            int index = (i + this.RoomNumber / 2) % this.RoomNumber;
            if (this.roomsRegister[index] != null)
            {
                this.roomsRegister[index] = null;
                this.emptyRooms++;
                return true;
            }
        }

        return false;
    }

    public bool EmptyRoom()
    {
        return this.emptyRooms > 0;
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < this.RoomNumber; i++)
        {
            sb.AppendLine(this.Print(i));
        }
        return sb.ToString();
    }

    public string Print(int index)
    {
        return this.roomsRegister[index]?.ToString() ?? "Room empty";
    }
}