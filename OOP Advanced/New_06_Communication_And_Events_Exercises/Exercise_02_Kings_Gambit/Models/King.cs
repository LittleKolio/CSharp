namespace Exercise_02_Kings_Gambit.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class King : IKing
    {
        public event GetAttackedEventHandler GetAttackedEvent;

        public King(string name)
        {
            this.Name = name;
            this.collection = new HashSet<ISubordinate>();
        }

        public string Name { get; }

        private HashSet<ISubordinate> collection;
        public IReadOnlyCollection<ISubordinate> Subordinates
        {
            get { return this.collection; }
        }

        public void Attacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            this.GetAttackedEvent?.Invoke();
        }

        public void AddSubordinates(ISubordinate sub)
        {
            this.collection.Add(sub);
            this.GetAttackedEvent += sub.ReactToAttack;
        }
    }
}