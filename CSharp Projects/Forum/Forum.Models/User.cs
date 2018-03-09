namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class User
    {
        public User(int id, string name, string password, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Posts = new List<int>(posts);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<int> Posts { get; set; }

        public override string ToString()
        {
            return string.Format(
                    "{0};{1};{2};{3}",
                    this.Id,
                    this.Name,
                    this.Password,
                    string.Join(',', this.Posts));
        }
    }
}
