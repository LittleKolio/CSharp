namespace BookShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class BookShopContext : DbContext
    {

        public BookShopContext()
            : base("BookShopContext")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("RelatedBooks");
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedId");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}