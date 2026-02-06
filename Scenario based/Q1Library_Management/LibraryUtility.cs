using LibraryManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public class LibraryUtility
    {
        private readonly List<Book> books = new();
        private int currentId = 1;

        public void AddBook(string title, string author, string genre, int year)
        {
            books.Add(new Book(currentId++, title, author, genre, year));
        }
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            var result = new SortedDictionary<string, List<Book>>();

            foreach (var book in books)
            {
                if (!result.ContainsKey(book.Genre))
                {
                    result[book.Genre] = new List<Book>();
                }

                result[book.Genre].Add(book);
            }

            return result;
        }


        public List<Book> GetBooksByAuthor(string author)
        {
            return books
                .Where(b => string.Equals(b.Author, author, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }
}
