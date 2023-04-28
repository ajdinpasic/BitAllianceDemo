using LibraryManagement.DAL.Data;
using LibraryManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        
        public Book AddNewBook(string title, string author, string publisher, DateTime releaseYear)
        {
            var books = GetStaticBooks();
            var book = new Book { Title = title, Author = author, Publisher = publisher, ReleaseYear = releaseYear };
            //books.Add(book); Mimic DB
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
           return GetStaticBooks();
        }

        public Book GetBook(Guid bookId)
        {
            var books = GetStaticBooks();

            return (books.Where(y => y.BookId == bookId).FirstOrDefault())!; //lambda expression => anonymous function
        }

        public static List<Book> GetStaticBooks()
        {
             List<Book> booksGlobal = new List<Book>
            {
                new Book
                {
                    BookId = new Guid("F10C7EF0-2AF7-49BE-A567-F537884899B5"),
                    Title = "Title",
                    Author = "Author",
                    Publisher = "Publisher",
                    ReleaseYear = DateTime.Now
                },
                 new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = "Title v2",
                    Author = "Author v2",
                    Publisher = "Pulisher v2",
                    ReleaseYear = DateTime.Now
                }
            };

            return booksGlobal;
    }
    }
}
