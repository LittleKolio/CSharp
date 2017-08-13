namespace Events_Exercises.Exercises_02.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class King
    {
        public event EventHandler UnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            if (this.UnderAttack != null)
            {
                this.UnderAttack(this, new EventArgs());
            }
           
        }
    }
}
