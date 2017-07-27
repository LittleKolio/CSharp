using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    //private readonly IList<Book> books;
    public IList<Book> Books { get; private set; }

    public Library(params Book[] books)
    {
        this.Books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.Books);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        public IList<Book> Books { get; private set; }
        private int currentIndex;

        public LibraryIterator(IList<Book> books)
        {
            this.Reset();
            this.Books = books;
        }

        public Book Current
        {
            get { return this.Books[this.currentIndex]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.Books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}