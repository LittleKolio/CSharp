namespace Exercise_08_Create_User
{
    using System;
    using System.Collections.Generic;
    //----------------
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;

    class Start
    {
        static void Main()
        {
            var context = new UsersContext();
            using (context)
            {
                context.Database.Initialize(true);

                //var u1 = new User()
                //{
                //    Username = "Puika",
                //    Password = "!aW_sdgd@5",
                //    Email = "dudu_hoho@ekek.fg",
                //    ProfilePicture = Util.f_ckingFile("../../Pictures/f1f413d6d07912be6080c08b186630ac.jpg"),
                //    RegisteredOn = new DateTime(2008, 3, 9),
                //    LastTimeLoggedIn = new DateTime(2012, 2, 5),
                //    Age = 60,
                //    IsDeleted = false
                //};

                //var u2 = new User()
                //{
                //    Username = "Kartof",
                //    Password = "%aR_sd28Y@5",
                //    Email = "mumu_dada@ekek.fg",
                //    ProfilePicture = Util.f_ckingFile("../../Pictures/b6f01ebccaf1d268211bf443603a0bb0.jpg"),
                //    RegisteredOn = new DateTime(2003, 3, 9),
                //    LastTimeLoggedIn = new DateTime(2010, 2, 5),
                //    Age = 61,
                //    IsDeleted = false
                //};

                var u5 = new User()
                {
                    Username = "Kartof",
                    Password = "%aR_s%aR_sd28Y@5",
                    Email = "mumu_dada@ekek.fg",
                    ProfilePicture = Util.f_ckingFile("../../Pictures/b6f01ebccaf1d268211bf443603a0bb0.jpg"),
                    RegisteredOn = new DateTime(2003, 3, 9),
                    LastTimeLoggedIn = new DateTime(2010, 2, 5),
                    Age = 11,
                    IsDeleted = false
                };

                //context.Users.AddRange(new List<User> { u1, u2 });
                context.Users.Add(u5);
                context.SaveChanges();
            }
        }
    }
}
