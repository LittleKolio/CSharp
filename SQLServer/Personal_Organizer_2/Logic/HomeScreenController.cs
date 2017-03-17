namespace Logic
{
    using Data;
    using Input;
    using ScreenElements;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomeScreenController
        : ScreenController
    {
        public HomeScreenController(OrganizerEntities context, KeyboardInput parse) 
            : base(context, parse)
        {
            var contacts = context.People.Select(p => p.FirstName + " " + p.LastName).ToList();
            this.root = new Paragraph(1, 1, contacts);
        }
    }
}
