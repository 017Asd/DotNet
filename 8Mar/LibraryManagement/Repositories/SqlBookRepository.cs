using LibraryManagement.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly LibraryDbContext context;

        public SqlBookRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public List<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return context.Books.Find(id);
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }
}