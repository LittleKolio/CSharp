using System;
using System.Collections;
using System.Collections.Generic;

public class RoomsRegister : IEnumerable<int>
{
    private readonly List<Pet> rooms;
    private readonly int startRoom;

    public RoomsRegister(int roomNumber)
    {
        this.startRoom = roomNumber / 2;
        this.rooms = new List<Pet>(new Pet[roomNumber]);
    }

    public Pet this[int index]
    {
        get { return this.rooms[index]; }
        set { this.rooms[index] = value; }
    }

    public IEnumerator<int> GetEnumerator()
    {
        yield return this.startRoom;

        int step = 1;

        while (step < this.startRoom)
        {
            yield return this.startRoom - step;
            yield return this.startRoom + step;
            step++;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}