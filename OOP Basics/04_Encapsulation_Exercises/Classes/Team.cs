namespace Encapsulation_Exercises.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Team
    {
        public string Name { get; private set; }
        public List<Player> Players { get; private set; }

        //public int Rating { get; }

        public Team(string name)
        {
            this.Name = name;
            this.Players = new List<Player>();
        }

        public int Rating()
        {
            return (int)Math.Round(
                this.Players.Sum(p => p.SkillLevel()), 
                MidpointRounding.AwayFromZero);
        }
    }
}
