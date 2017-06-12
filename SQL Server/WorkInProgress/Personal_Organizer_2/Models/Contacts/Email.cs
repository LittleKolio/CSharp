namespace Models.Contacts
{
    using System;
    using System.Collections.Generic;

    public class Email
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
