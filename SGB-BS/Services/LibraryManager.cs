using SGB_BS.Algorithms;
using SGB_BS.Models;

namespace SGB_BS.Services
{
    public class LibraryManager
    {
        private const int Capacity = 20;

        private readonly Book[] books = new Book[Capacity];
        private int count;
        private readonly BookSearcher searcher = new BookSearcher();

        public int Count => count;
        public int LastComparisons => searcher.Comparisons;

        public LibraryManager()
        {
            LoadInitialData();
        }

        public Book? SearchById(int id)
        {
            return searcher.BinarySearchById(books, count, id);
        }

        public Book? GetBookAt(int index)
        {
            if (index < 0 || index >= count)
                return null;

            return books[index];
        }

        private void LoadInitialData()
        {
            Add(new Book(10, "Clean Code", "Robert C. Martin", 2008));
            Add(new Book(20, "The Pragmatic Programmer", "Andrew Hunt", 1999));
            Add(new Book(30, "Design Patterns", "Erich Gamma", 1994));
            Add(new Book(40, "Refactoring", "Martin Fowler", 1999));
            Add(new Book(50, "Clean Architecture", "Robert C. Martin", 2017));
            Add(new Book(60, "Domain-Driven Design", "Eric Evans", 2003));
            Add(new Book(70, "Algorithms", "Robert Sedgewick", 1983));
            Add(new Book(80, "Introduction to Algorithms", "Thomas H. Cormen", 1990));
            Add(new Book(90, "Code Complete", "Steve McConnell", 1993));
            Add(new Book(100, "Working Effectively with Legacy Code", "Michael Feathers", 2004));
        }

        private void Add(Book book)
        {
            if (count >= Capacity)
                throw new InvalidOperationException("El arreglo está lleno.");

            books[count] = book;
            count++;
        }
    }
}