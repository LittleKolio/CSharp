namespace Exercise_02_Kings_Gambit.Models
{
    using Contracts;
    using System;

    public abstract class Subordinate : ISubordinate
    {
        protected Subordinate(string name, string action, int hits)
        {
            this.Name = name;
            this.Action = action;
            this.Hits = hits;
            this.IsAlive = true;
        }

        public string Name { get; }

        public string Action { get; }

        public int Hits { get; private set; }

        public bool IsAlive { get; private set; }

        public void Die()
        {
            this.IsAlive = false;
        }

        public void ReactToAttack()
        {
            //if (this.IsAlive)
            //{
            //    string respond = $"{this.GetType().Name} {this.Name} is {this.Action}!";
            //    respond = respond.Replace("RoyalGuard", "Royal Guard");

            //    Console.WriteLine(respond);
            //}

            string respond = $"{this.GetType().Name} {this.Name} is {this.Action}!";
            respond = respond.Replace("RoyalGuard", "Royal Guard");

            Console.WriteLine(respond);
        }

        public void TakeHit()
        {
            this.Hits--;
            if (this.Hits <= 0)
            {
                this.Die();
            }
        }
    }
}