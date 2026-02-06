using LibraryManagement;
using System;
class Program
{
    static void Main()
    {
        var library = new LibraryUtility();

        library.AddBook("1984", "George Orwell", "Fiction", 1949);
        library.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
        library.AddBook("The Da Vinci Code", "Dan Brown", "Mystery", 2003);
        library.AddBook("Animal Farm", "George Orwell", "Fiction", 1945);

        var groupedBooks = library.GroupBooksByGenre();
        foreach (var genre in groupedBooks)
        {
            Console.WriteLine($"\nGenre: {genre.Key}");
            foreach (var book in genre.Value)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
        Console.WriteLine("\nBooks by George Orwell:");
        foreach (var book in library.GetBooksByAuthor("George Orwell"))
        {
            Console.WriteLine(book.Title);
        }

        Console.WriteLine($"\nTotal Books: {library.GetTotalBooksCount()}");

        foreach (var genre in groupedBooks)
        {
            Console.WriteLine($"{genre.Key}: {genre.Value.Count} books");
        }
    }
}
