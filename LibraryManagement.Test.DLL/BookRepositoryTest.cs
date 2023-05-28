using AutoFixture;
using FluentAssertions;
using LibraryManagement.DAL;
using LibraryManagement.DAL.Data;
using LibraryManagement.DAL.Interfaces;
using LibraryManagement.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Test.DLL
{
    [TestClass]
    public class BookRepositoryTest
    {
        private IBookRepository bookRepository;
        private Fixture fixture;
        private LibraryDBContext mockContext;

        public BookRepositoryTest()
        {
            mockContext = new LibraryDBContext(new DbContextOptionsBuilder<LibraryDBContext>()
                .UseInMemoryDatabase("Test").Options);


        }

        [TestInitialize]
        public void SetUp()
        {
            bookRepository = new BookRepository(mockContext);
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public void GetBooks_ShouldReturnCollection()
        {
            // Arrange
            var expectedBooks = fixture.CreateMany<Book>().ToList();
            mockContext.Book.AddRange(expectedBooks);
            mockContext.SaveChanges();

            // Act
            var actualBooks = bookRepository.GetAllBooks();

            // Assert
            actualBooks.Should().BeEquivalentTo(expectedBooks);
        }

        [TestMethod]
        public void GetBooks_ShouldReturnCorrectBook()
        {
            // Arrange
            Guid bookId = Guid.NewGuid();
            var expectedBook = fixture.Build<Book>().With(x => x.BookId, bookId).Create();
            mockContext.Book.AddRange(expectedBook);
            mockContext.SaveChanges();

            // Act
            var actualBook = bookRepository.GetBook(bookId);

            // Assert
            actualBook.Should().BeEquivalentTo(expectedBook);
        }
    }
}
