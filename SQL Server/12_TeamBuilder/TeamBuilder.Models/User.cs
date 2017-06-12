namespace TeamBuilder.Models
{
    using System.ComponentModel.DataAnnotations;
    using Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// User may send join request on team in order to be added to that team
    /// User can be part of more than one team
    /// </summary>

    public class User
    {
        public User()
        {
            this.ReceivedInvitations = new HashSet<Invitation>();
            this.InTeams = new HashSet<Team>();
            this.TeamsCreator = new HashSet<Team>();
            this.EventsCreator = new HashSet<Event>();
        }
        public int Id { get; set; }
        [MinLength(3), MaxLength(25), Required]
        public string Username { get; set; }
        [Password(6, 30, Digit = true, Uppercase = true), Required]
        public string Password { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Invitation> ReceivedInvitations { get; set; }
        public virtual ICollection<Team> InTeams { get; set; }
        public virtual ICollection<Team> TeamsCreator { get; set; }
        public virtual ICollection<Event> EventsCreator { get; set; }
    }
}
