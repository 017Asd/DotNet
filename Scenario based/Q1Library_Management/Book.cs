using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
        public class Book
        {
            public int Id { get; }
            public string Title { get; }
            public string Author { get; }
            public string Genre { get; }
            public int PublicationYear { get; }

            public Book(int id, string title, string author, string genre, int publicationYear)
            {
                Id = id;
                Title = title;
                Author = author;
                Genre = genre;
                PublicationYear = publicationYear;
            }
        }
    }

