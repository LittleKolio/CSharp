namespace Exercise_08_Create_User
{
    using System;
    using System.Collections.Generic;
    //-------------------
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30), MinLength(4)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50), MinLength(6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*(\W|_))[^ ]{6,50}$")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9]+[\.\-_])*([a-zA-Z0-9]+)@([a-zA-Z0-9]+\.)+([a-z]+)$")]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120, ErrorMessage="F this age.")]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
