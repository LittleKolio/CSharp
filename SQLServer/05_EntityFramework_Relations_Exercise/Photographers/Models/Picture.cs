namespace Photographers.Models
{
    using System;
    using System.Collections.Generic;

    public class Picture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }
    }
}
