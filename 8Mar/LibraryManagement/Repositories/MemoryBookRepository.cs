using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private List<Book> books;

        public MemoryBookRepository()
        {
            books = new List<Book>()
            {
                new Book{ BookId = 1, Title = "The Secret", Author="Joe Vitale", Price=500 },
                new Book{ BookId = 2, Title = "The Palace of Illusions", Author="Chitra Lekha", Price=650 },
                new Book{ BookId = 3, Title = "Chanakya Neeti", Author="Radhakrishnam Pillai", Price=700 }
            };
        }
        public List<Book> GetAllBooks()
        {
            return books;
        }
        public Book GetBookById(int id)
        {
            return books.FirstOrDefault(x => x.BookId == id);
        }
        public void AddBook(Book book)
        {
            book.BookId = books.Max(x => x.BookId) + 1;
            books.Add(book);
        }
        public void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.BookId == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}