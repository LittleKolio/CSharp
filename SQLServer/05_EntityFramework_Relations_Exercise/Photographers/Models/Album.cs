namespace Photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool Public { get; set; }

        public virtual ICollection<PhotographerAlbum> PhotographerAlbums { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.PhotographerAlbums = new HashSet<PhotographerAlbum>();
        }
    }
}
