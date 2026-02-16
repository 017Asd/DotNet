using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class Program
    {
        public static List<string> splitter(string input)
        {
            return input.Split(' ').ToList();
        }

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> inputs = splitter(input);

            Book book = new Book(
                inputs[0],
                inputs[1],
                int.Parse(inputs[2]),
                int.Parse(inputs[3])
            );

            BookUtility utility = new BookUtility();
            string choice = "";

            

            do
            {
                choice = Console.ReadLine();

                switch (choice)
            {
                    case "1":
                        utility.GetBookDetails(book);
                        break;

                    case "2":
                        int newPrice = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(book, newPrice);
                        break;

                    case "3":
                        int newStock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(book, newStock);
                        break;

                    case "4":
                        break;
                    }

            } while (choice != "4");


            
        }
    }
}
