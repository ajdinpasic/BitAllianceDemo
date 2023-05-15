using LibraryManagement.DAL.Data;
using LibraryManagement.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDBContext _dbContext;

        public BookRepository(LibraryDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Book AddNewBook(string title, string author, string publisher, DateTime releaseYear)
        {
            //var books = GetStaticBooks();
            var book = new Book { BookId = Guid.NewGuid(),Title = title, Author = author, Publisher = publisher, ReleaseYear = releaseYear };
            //books.Add(book); Mimic DB
            _dbContext.Book.Add(book);
            _dbContext.SaveChanges(); // commit 
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            //return _dbContext.Book.AsQueryable();// SELECT * FROM Book
            return _dbContext.Book.Include(c=> c.Rentals);
            // SELECT * FROM Book 
            // INNER JOIN Rental on Book.BookId = Rental.BookId
        }

        // SELECT * FROM book where bookid = 1

        public Book GetBook(Guid bookId)
        {
            return (_dbContext.Book.Where(x=> x.BookId == bookId).FirstOrDefault())!;

            //return (books.Where(y => y.BookId == bookId).FirstOrDefault())!; //lambda expression => anonymous function
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

        public void DeleteBook(Guid id)
        {
            var book = _dbContext.Book.Where(x => x.BookId == id).First();
            _dbContext.Book.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
