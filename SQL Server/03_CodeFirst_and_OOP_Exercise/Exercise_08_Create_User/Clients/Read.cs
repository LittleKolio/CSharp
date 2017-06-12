namespace Exercise_08_Create_User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Read
    {
        static void Main()
        {
            var context = new UsersContext();
            using (context)
            {
                var f_ckingFile = context.Users.Find(1).ProfilePicture;

                Util.readTheF_ckingFile("../../Pictures/test_user1.jpg", f_ckingFile);
            }

        }
    }
}
