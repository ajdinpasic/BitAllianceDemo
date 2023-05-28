using AutoFixture;
using LibraryManagement.BLL.Interfaces;
using LibraryManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using LibraryManagement.BLL.Data;
using FluentAssertions;

namespace LibraryManagement.Test.API
{
    // TestInitialize TestCleanUp ClassInitialize ClassCleanup 
    [TestClass]
    public class BookControllerTest
    {
        private Fixture fixture;
        private BookController bookController;
        private Mock<IBookService> bookService;

        [TestInitialize]
        public void SetUp()
        {
            fixture = new Fixture();
            bookService = new Mock<IBookService>();
            bookController = new BookController(bookService.Object);
        }

        [TestMethod]
        public void GetBooks_ShouldReturnCollection()
        {
            // Triple A pattern

            // Arrange
            var expectedBooks = fixture.CreateMany<BookDTO>().ToList();
 
            bookService.Setup(x => x.GetBooks()).Returns(expectedBooks);
            // Act
            var actualBooks = bookController.GetBooks();
            // Assert
            actualBooks.Should().BeEquivalentTo(expectedBooks);
        }

        [TestMethod]
        public void GetBooks_ShouldBookDTO()
        {
            // Triple A pattern

            // Arrange
            var expectedBook = fixture.Create<BookDTO>();
            Guid bookId = Guid.NewGuid(); // A A A A A A A  A A A A A A A A A 
            bookService.Setup(x=> x.GetBook(bookId)).Returns(expectedBook);

            // Act
            var actualBook = bookController.Get(bookId);

            // Assert

            actualBook.Should().BeEquivalentTo(expectedBook);
        }
    }
}
