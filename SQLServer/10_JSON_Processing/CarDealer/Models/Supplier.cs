namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// One supplier can supply many parts and each part can be delivered by only one supplier
    /// </summary>
    public class Supplier
    {
        private ICollection<Part> parts;
        public Supplier()
        {
            this.Parts = new HashSet<Part>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsImported { get; set; }

        public virtual ICollection<Part> Parts
        {
            get { return this.parts; }
            set { this.parts = value; }
        }
    }
}
