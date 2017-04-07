namespace BookCatalog.Data
{
    using BookCatalog.Models;
    using System;
    using System.Linq;

    public class Controller
    {
        public static void AddBook(BookDto book)
        {
            var genreId = GetGenreId(book.Genre);
            var authorId = GetAuthorId(book.Author);
            var createBook = new Book
            {
                AuthorId = authorId,
                Title = book.Title,
                Price = book.Price,
                RefNumber = book.RefNumber,
                Description = book.Description,
                PublishDate = book.PublishDate
            };

            var genre = GetGenre(genreId);

            var context = new BookCatalogContext();
            using (context)
            {
                //? WTF ? WTF ? WTF ? WTF ? WTF
                context.Genres.Attach(genre);
                //? WTF ? WTF ? WTF ? WTF ? WTF

                createBook.Genres.Add(genre);

                context.Books.Add(createBook);
                context.SaveChanges();
            }

        }

        public static int AddAuthor(string[] authorName)
        {
            var context = new BookCatalogContext();
            using (context)
            {
                var result = new Author
                {
                    FirstName = authorName[1],
                    LastName = authorName[0]
                };
                context.Authors.Add(result);
                context.SaveChanges();
                return result.Id;
            }
        }

        public static int GetAuthorId(string author)
        {
            var authorName = author.Split(
                ", ".ToCharArray(), 
                StringSplitOptions.RemoveEmptyEntries);
            var context = new BookCatalogContext();
            using (context)
            {
                var result = context.Authors
                    .Where(g => authorName.Contains(g.FirstName) && 
                        authorName.Contains(g.LastName))
                    .SingleOrDefault();
                if (result == null)
                {
                    return AddAuthor(authorName);
                }
                return result.Id;
            }
        }

        public static int AddGenre(string genre)
        {
            var context = new BookCatalogContext();
            using (context)
            {
                var result = new Genre
                {
                    Type = genre
                };
                context.Genres.Add(result);
                context.SaveChanges();
                return result.Id;
            }
        }

        public static int GetGenreId(string genre)
        {
            var context = new BookCatalogContext();
            using (context)
            {
                var result = context.Genres
                    .Where(g => g.Type == genre)
                    .SingleOrDefault();
                if (result == null)
                {
                    return AddGenre(genre);
                }
                return result.Id;
            }
        }

        public static Genre GetGenre(int genre)
        {
            var context = new BookCatalogContext();
            using (context)
            {
                return context.Genres.Find(genre);
            }
        }
    }
}
