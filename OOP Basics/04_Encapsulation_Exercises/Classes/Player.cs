namespace Encapsulation_Exercises.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Player
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception();
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception();
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception();
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception();
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception();
                }
                this.shooting = value;
            }
        }

        public Player(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public double SkillLevel()
        {
            return (this.Endurance + this.Sprint +
                this.Dribble + this.Passing + this.Shooting) / 5.0;
        }
    }
}
