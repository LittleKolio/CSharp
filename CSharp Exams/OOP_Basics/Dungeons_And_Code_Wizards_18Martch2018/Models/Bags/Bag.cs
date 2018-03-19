namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Bag
    {
        private double capacity;

        protected Bag(int capacity)
        {
            this.capacity = capacity;
            this.items = new List<Item>();
        }

        private List<Item> items;
        public ReadOnlyCollection<Item> Items
        {
            get { return new ReadOnlyCollection<Item>(this.items); }
        }

        public double Load => this.Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.capacity)
            {
                throw new InvalidOperationException(
                    Constants.Bag_IsFull);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = Validation.ItemInBag(this.Items, name);

            this.items.Remove(item);

            return item;
        }
    }
}
