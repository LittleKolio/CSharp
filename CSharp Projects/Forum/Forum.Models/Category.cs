using System;
using System.Collections.Generic;

namespace Forum.Models
{
    public class Category
    {
        public Category()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> Posts { get; set; }
    }
}
