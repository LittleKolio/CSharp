namespace BookCatalog.Logic
{
    using System;
    using System.Xml.Linq;
    using System.Linq;
    using System.Collections.Generic;
    using Data;

    public static class Import
    {
        public static ICollection<BookDto> XmlImpotr(string path)
        {
            XDocument doc = XDocument.Load(path);
            return doc.Root.Elements()
                .Select(ParseBook)
                .ToList();
        }

        public static BookDto ParseBook(XElement book)
        {
            var newBook = new BookDto
            {
                RefNumber = book.Attribute("id").Value,
                Author = book.Element("author").Value,
                Title = book.Element("title").Value,
                Genre = book.Element("genre").Value,
                Price = decimal.Parse(book.Element("price").Value),
                PublishDate = DateTime.Parse(book.Element("publish_date").Value),
                Description = book.Element("description").Value
            };
            return newBook;
        }
    }
}
