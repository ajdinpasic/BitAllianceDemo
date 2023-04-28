using LibraryManagement.BLL.Data;
using LibraryManagement.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.DAL.Interfaces;
using LibraryManagement.DAL.Data;
using LibraryManagement.DAL.Repositories;
using AutoMapper;

namespace LibraryManagement.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public BookDTO AddNewBook(string title, string author, string publisher, DateTime releaseYear)
        {
            var book = _bookRepository.AddNewBook(title, author, publisher, releaseYear);
            var convertedBook = new BookDTO
            {
                Author = book.Author,
                Title = book.Title,
                ReleaseYear = book.ReleaseYear
            };

            return convertedBook;
        }

        public BookDTO GetBook(Guid bookId)
        {
            var book = _bookRepository.GetBook(bookId);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            //var bookDTO = new BookDTO
            //{
            //    Author = book.Author,
            //    ReleaseYear = book.ReleaseYear,
            //    Title = book.Title

            //};

            return _mapper.Map<BookDTO>(book);
        }

        public IEnumerable<BookDTO> GetBooks()
        {

            IEnumerable<Book> books = _bookRepository.GetAllBooks();
            List<BookDTO> convertedBooks = new List<BookDTO>();
            //foreach(var item  in books)  // Conversion from MODEL/ENTITY to VIEW/DTO
            //{
            //    convertedBooks.Add(

            //        new BookDTO
            //        {
            //            Title = item.Title,
            //            Author = item.Author,
            //            ReleaseYear = item.ReleaseYear
            //        }

            //        );
            //}
            return _mapper.Map<List<BookDTO>>(books);
            //return convertedBooks;

        }
    }
}
