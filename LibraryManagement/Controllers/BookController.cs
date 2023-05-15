using Microsoft.AspNetCore.Mvc;
using LibraryManagement.BLL.Interfaces;
using LibraryManagement.BLL.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) {

            _bookService = bookService;

        }

        // GET: api/<BookController>
        //[Route("api/books")]
        [HttpGet]
        public IEnumerable<BookDTO> GetBooks()
        {
            return _bookService.GetBooks();
        }

        // GET api/<BookController>/5
        [HttpGet("{bookId}")]
        public BookDTO Get(Guid bookId)
        {
            if(bookId == Guid.Empty )
            {
                throw new Exception("Missing parameter name");
            }
            return _bookService.GetBook(bookId);
        }

        // POST api/<BookController>
        [HttpPost]
        public BookDTO Post([FromBody] PostBookDTO newBook )
        {

           return _bookService.AddNewBook(newBook.Title, newBook.Author, newBook.Publisher, newBook.ReleaseYear);
        }

        //// PUT api/<BookController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
