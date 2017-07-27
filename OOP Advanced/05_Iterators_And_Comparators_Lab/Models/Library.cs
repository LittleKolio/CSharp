using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    private readonly SortedSet<Book> books;
    //public SortedSet<Book> Books { get; private set; }

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books, new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books.ToList());
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