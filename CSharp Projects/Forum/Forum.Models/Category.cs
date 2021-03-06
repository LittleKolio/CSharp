﻿namespace Forum.Models
{
    using System;
    using System.Collections.Generic;

    public class Category
    {
        public Category(int id, string name, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Name = name;
            this.Posts = new List<int>(posts);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> Posts { get; set; }

        public override string ToString()
        {
            return string.Format(
                    "{0};{1};{2}",
                    this.Id,
                    this.Name,
                    string.Join(',', this.Posts));
        }
    }
}
