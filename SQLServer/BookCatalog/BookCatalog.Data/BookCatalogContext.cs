namespace BookCatalog.Data
{
    using Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Linq;

    public class BookCatalogContext : DbContext
    {

        public BookCatalogContext()
            : base("name=BookCatalogContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Genre>()
            //    .Property(g => g.Type)
            //    .HasColumnAnnotation(
            //        IndexAnnotation.AnnotationName,
            //        new IndexAnnotation(
            //            new IndexAttribute("IX_Type", 1) { IsUnique = true }
            //            ));

            base.OnModelCreating(modelBuilder);
        }
    }
}