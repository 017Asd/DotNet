using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Catalog<Book> library = new Catalog<Book>();

        Book book1 = new Book
        {
            ISBN = "978-3-16-148410-0",
            Title = "C# Programming",
            Author = "John Sharp",
            Genre = "Programming"
        };

        Book book2 = new Book
        {
            ISBN = "978-1-23-456789-0",
            Title = "LINQ Deep Dive",
            Author = "Jane Miller",
            Genre = "Programming"
        };

        library.AddItem(book1);
        library.AddItem(book2);

        var programmingBooks = library["Programming"];
        Console.WriteLine(programmingBooks.Count); // 2

        var johnsBooks = library.FindBooks(b => b.Author.Contains("John"));
        Console.WriteLine(johnsBooks.Count()); // 1
    }
}
