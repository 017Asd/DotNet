namespace Assignment
{
    public class BookUtility
    {
        private Book book;
        public void GetBookDetails(Book book)
        {
            Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");

        }
        public void UpdateBookPrice(Book book,int newPrice)
        {
            Console.WriteLine($"Updated Price: {newPrice}");
        } 
        public void UpdateBookStock(Book book,int newStock)
        {
            Console.WriteLine($"Updated Stock: {newStock}");
        }
    }
}