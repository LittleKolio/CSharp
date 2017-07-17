namespace Defining_Classes_Exercises.Classes
{
    class Engine
    {
        private int speed;
        private int power;
        public Engine(int speed, int power)
        {
            this.speed = speed;
            this.power = power;
        }
        public int Power
        {
            get { return this.power; }
        }
    }
}
