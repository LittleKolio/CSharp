namespace TeamBuilder.Models
{
    using Attributes;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Team consists of users
    /// Team can send invitation to user so he can join
    /// Team can participate in multiple events
    /// User can create team and becom creator
    /// </summary>

    public class Team
    {
        public Team()
        {
            this.Invitations = new HashSet<Invitation>();
            this.Users = new HashSet<User>();
            this.Events = new HashSet<Event>();
        }
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string Description { get; set; }
        [ExactLength(3), Required]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
