namespace Photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Photographer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate  { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<PhotographerAlbum> PhotographerAlbums { get; set; }
        public Photographer()
        {
            this.PhotographerAlbums = new HashSet<PhotographerAlbum>();
        }
    }
}
