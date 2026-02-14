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
                int updatePrice = 0;
                int updateStock = 0;

                if (choice.Length > 1)
                {
                    List<string> choices = splitter(choice);
                    choice = choices[0];

                    if (choice == "2")
                        updatePrice = int.Parse(choices[1]);

                    if (choice == "3")
                        updateStock = int.Parse(choices[1]);
                }

                switch (choice)
                {
                    case "1":
                        utility.GetBookDetails(book);
                        break;

                    case "2":
                        utility.UpdateBookPrice(book, updatePrice);
                        break;

                    case "3":
                        utility.UpdateBookStock(book, updateStock);
                        break;

                    case "4":
                        break;
                }

            } while (choice != "4");
        }
    }
}
