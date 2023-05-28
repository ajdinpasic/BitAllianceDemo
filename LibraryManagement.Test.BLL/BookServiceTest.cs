using AutoFixture;
using AutoMapper;
using FluentAssertions;
using LibraryManagement.BLL.Data;
using LibraryManagement.BLL.Interfaces;
using LibraryManagement.BLL.Services;
using LibraryManagement.DAL.Data;
using LibraryManagement.DAL.Interfaces;
using Moq;
using System.Runtime.CompilerServices;

namespace LibraryManagement.Test.BLL
{
    [TestClass]
    public class BookServiceTest
    {
        private Fixture fixture;
        private IBookService bookService;
        private Mock<IBookRepository> bookRepository;
        private IMapper mapper;
     


        public BookServiceTest()
        {
            
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile.AutoMapperProfile());
            }));
           
        }

        [TestInitialize]
        public void SetUp()
        {
            fixture = new Fixture();
            bookRepository = new Mock<IBookRepository>();
            bookService = new BookService(bookRepository.Object,mapper);
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
  .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public void GetBooks_ShouldReturnCollection()
        {
            // Triple A pattern

            // Arrange
            var expectedBooks = fixture.CreateMany<Book>().ToList();

            bookRepository.Setup(x => x.GetAllBooks()).Returns(expectedBooks);
            // Act
            var actualBooks = bookService.GetBooks();
            // Assert
            actualBooks.Should().BeEquivalentTo(mapper.Map<List<BookDTO>>(expectedBooks));
        }

        [TestMethod]
        public void GetBooks_ShouldReturnBookDTO()
        {
            // Triple A pattern

            // Arrange
            
            Guid bookId = Guid.NewGuid();
            var expectedBook = fixture.Create<BookDTO>();
            bookRepository.Setup(x => x.GetBook(bookId)).Returns(mapper.Map<Book>(expectedBook));
            // Act
            var actualBook = bookService.GetBook(bookId);
            // Assert
            actualBook.Should().BeEquivalentTo(expectedBook);
        }


    }

    

}


