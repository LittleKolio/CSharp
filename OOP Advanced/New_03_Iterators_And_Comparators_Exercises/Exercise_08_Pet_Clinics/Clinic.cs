namespace Exercise_08_Pet_Clinics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Clinic
    {
        private Pet[] rooms;
        private int middle;

        public Clinic(string name, int rooms)
        {
            this.Name = name;
            this.InitializeRooms(rooms);
            this.middle = rooms / 2;
        }

        private void InitializeRooms(int rooms)
        {
            if (rooms % 2 == 0)
            {
                throw new InvalidOperationException(
                    "Invalid Operation!");
            }
            this.rooms = new Pet[rooms];
        }

        public string Name { get; }

        public bool HasEmptyRooms() => this.rooms.Any(p => p == null);

        public bool Add(Pet pet)
        {
            bool isAdded = false;

            if (!this.HasEmptyRooms() || pet == null)
            {
                return isAdded;
            }

            for (int i = 0; i <= this.middle; i++)
            {
                if (this.rooms[this.middle - i] == null)
                {
                    this.rooms[this.middle - i] = pet;
                    isAdded = true;
                    break;
                }

                if (this.rooms[this.middle + i] == null)
                {
                    this.rooms[this.middle + i] = pet;
                    isAdded = true;
                    break;
                }
            }

            return isAdded;
        }

        public bool Release()
        {
            bool isRelease = false;

            if (this.rooms.All(p => p == null))
            {
                return isRelease;
            }

            for (int i = 0; i < this.rooms.Length; i++)
            {
                int index = (this.middle + i) % this.rooms.Length;
                if (this.rooms[index] != null)
                {
                    this.rooms[index] = null;
                    isRelease = true;
                    break;
                }
            }

            return isRelease;
        }

        public void Print(int room)
        {
            if (this.rooms[room - 1] == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(this.rooms[room - 1]);
            }
        }

        public void Print()
        {
            if (this.rooms.All(p => p == null))
            {
                throw new InvalidOperationException(
                    "Rooms are empty");
            }

            for (int room = 1; room <= this.rooms.Length; room++)
            {
                this.Print(room);
            }
        }
    }
}
