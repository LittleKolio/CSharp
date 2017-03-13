namespace Exercise_08_Create_User
{
    using System;
    using System.Data.Entity;

    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("name=UsersContext")
        {
            Database.SetInitializer(
            new DropCreateDatabaseIfModelChanges<UsersContext>()
            //new DropCreateDatabaseAlways<UsersContext>()
            );
        }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<User>();
        //}
    }
} 