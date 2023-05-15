using LibraryManagement.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetBooks();
        BookDTO GetBook(Guid BookId);
        BookDTO AddNewBook(string title, string author,
             string publisher, DateTime releaseYear);

        void DeleteBook(Guid BookId);
    }
}
