namespace BookCatalog.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Logic;

    class Startup
    {
        static void Main()
        {
            //1. Initialize DataBase
            //Init.InitDB();

            //2. test Import from Logic
            //var books = Import.XmlImpotr(@"../../../books.xml");

            //3. test Controller from Data
            //var id = Controller.GetGenreId("Fantasy");
            //Console.WriteLine(id);

            //4. test Controller from Data
            //var id = Controller.GetAuthorId("Gambardella, Matthew");
            //Console.WriteLine(id);

            var books = Import.XmlImpotr(@"../../../books.xml");
            foreach (var book in books)
            {
                Controller.AddBook(book);
                Console.WriteLine($"Added: {book.Title}");
            }
        }
    }
}
