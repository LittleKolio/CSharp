namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// One event may have several teams
    /// User can create event and becom creator
    /// </summary>

    public class Event
    {
        private DateTime startDate;
        private DateTime endDate;

        public Event()
        {
            this.Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        [MaxLength(25), Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, 
            DataFormatString = "DD/MM/YYYY HH:mm")]
        public DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                if (this.endDate != null && 
                    this.endDate > value)
                { this.startDate = value; }
            }
        }

        [DisplayFormat(ApplyFormatInEditMode = true, 
            DataFormatString = "DD/MM/YYYY HH:mm")]
        public DateTime EndDate
        {
            get { return this.endDate; }
            set
            {
                if (this.startDate != null && 
                    this.startDate < value)
                { this.endDate = value; }
            }
        }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
