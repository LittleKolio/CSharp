namespace Photographers.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Util;

    public class Tag
    {
        public int Id { get; set; }

        [Tag]
        //[CustomMinLength(MinLength = 20)]
        public string Label { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
    }
}
