using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.DAL.Data;

namespace LibraryManagement.DAL.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBook(Guid id);
        Book AddNewBook(string title, string author,
           string publisher, DateTime releaseYear);
    }
}
