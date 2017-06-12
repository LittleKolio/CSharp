namespace BookShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data;
    using System.IO;
    using Models;
    using System.Globalization;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BookShop.Data.BookShopContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShopContext context)
        {
            SeedAuthors(context);
            SeedBooks(context);
            SeedCategories(context);
        }

        public static void SeedAuthors(BookShopContext context)
        {
            string[] authors = File.ReadAllLines(
                "../../Import/authors.csv");

            for (int i = 1; i < authors.Length; i++)
            {
                string[] data = authors[i]
                    .Split(',')
                    .Select(arg => arg.Replace("\"", string.Empty))
                    .ToArray();

                Author author = new Author()
                {
                    FirstName = data[0],
                    LastName = data[1]
                };

                context.Authors.AddOrUpdate(a => new { a.FirstName, a.LastName }, author);
            }
        }

        public static void SeedBooks(BookShopContext context)
        {
            int authorsCount = context.Authors.Local.Count;

            string[] books = File.ReadAllLines(
                "../../Import/books.csv");

            for (int i = 1; i < books.Length; i++)
            {
                string[] data = books[i]
                    .Split(',')
                    .Select(arg => arg.Replace("\"", string.Empty))
                    .ToArray();

                int authorIndex = i % authorsCount;

                Book book = new Book
                {
                    Author = context.Authors.Local[authorIndex],
                    EditionType = (EditionType)int.Parse(data[0]),
                    ReleaseDate = DateTime.ParseExact(
                        data[1], "d/M/yyyy", CultureInfo.InvariantCulture),
                    Copies = int.Parse(data[2]),
                    Price = decimal.Parse(data[3]),
                    AgeRestriction = (AgeRestriction)int.Parse(data[4]),
                    Title = data[5]
                };

                context.Books.AddOrUpdate(b => new { b.Title, b.AuthorId }, book);
            }
        }

        public static void SeedCategories(BookShopContext context)
        {
            int booksCount = context.Books.Local.Count;
            string[] categories = File.ReadAllLines(
                "../../Import/categories.csv");

            for (int i = 1; i < categories.Length; i++)
            {
                string[] data = categories[i]
                  .Split(',')
                  .Select(arg => arg.Replace("\"", string.Empty))
                  .ToArray();

                var category = new Category { Name = data[0] };

                int bookIndex = (i * 30) % booksCount;

                for (int j = 0; j < bookIndex; j++)
                {
                    Book book = context.Books.Local[j];
                    category.Books.Add(context.Books.Local[j]);
                }

                context.Categories.AddOrUpdate(c => c.Name, category);
            }
        }
    }
}