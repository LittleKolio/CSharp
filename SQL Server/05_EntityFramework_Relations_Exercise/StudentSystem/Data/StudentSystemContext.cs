namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using Models;
    using Migrations;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
            Database.SetInitializer(
                //new DropCreateDatabaseAlways<StudentSystemContext>()
                //new StudentSystemInitializer()
                new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>()
            );
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(8, 2);

            #region DatabaseGeneratedOption.None
            //modelBuilder.Entity<Course>()
            //    .Property(c => c.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //modelBuilder.Entity<Student>()
            //    .Property(s => s.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //modelBuilder.Entity<Homework>()
            //    .Property(h => h.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //modelBuilder.Entity<Resource>()
            //    .Property(r => r.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            #endregion
        }
    }
}