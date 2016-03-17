using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LMS.Domain.Entities;
using Moq;
using System.Data.Entity;
using LMS.Domain.Repositories;
using System.Runtime.Remoting.Messaging;

namespace LMS.Domain.UnitTests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private Mock<LmsDbContext> _dbContext;

        [TestInitialize]
        public void Setup()
        {
            _dbContext = new Mock<LmsDbContext>();

            CallContext.LogicalSetData(LMS.Domain.Consts.DBCONTEXT_KEY, _dbContext.Object);
        }

        [TestMethod]
        public void GivenBookTitleWhenGetBooksThenReturnBooks()
        {
            //Arrange
            string title = "Book1";
            var dbSetMock = TestableBook.GetDbSetMock<Book>(TestableBook.GetStubBooks().AsQueryable());
            _dbContext.Setup(x => x.Book).Returns(dbSetMock.Object);

            //Act
            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooks(string.Empty, title, string.Empty, string.Empty);

            //Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(books.First().Title, title);
        }

        [TestMethod]
        public void GivenAuthorWhenGetBooksThenReturnBooks()
        {
            //Arrange
            string author = "John";
            var dbSetMock = TestableBook.GetDbSetMock<Book>(TestableBook.GetStubBooks().AsQueryable());

            _dbContext.Setup(x => x.Book).Returns(dbSetMock.Object);
            //Act
            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooks(string.Empty, string.Empty, string.Empty, author);

            //Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(books.First().Author.Name, author);
        }

        [TestMethod]
        public void GivenISBNCodeWhenGetBooksThenReturnBooks()
        {
            //Arrange
            string isbnCode = "Ib122323m98";
            var dbSetMock = TestableBook.GetDbSetMock<Book>(TestableBook.GetStubBooks().AsQueryable());

            _dbContext.Setup(x => x.Book).Returns(dbSetMock.Object);
            //Act
            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooks(isbnCode, string.Empty, string.Empty, string.Empty);

            //Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(books.First().ISBNCode, isbnCode);
        }

        [TestMethod]
        public void GivenGenreWhenGetBooksThenReturnBooks()
        {
            //Arrange
            string genre = "History";
            var dbSetMock = TestableBook.GetDbSetMock<Book>(TestableBook.GetStubBooks().AsQueryable());

            _dbContext.Setup(x => x.Book).Returns(dbSetMock.Object);
            //Act
            var bookRepository = new BookRepository();
            var books = bookRepository.GetBooks(string.Empty, string.Empty,genre, string.Empty);

            //Assert
            Assert.IsNotNull(books);
            Assert.AreEqual(books.First().Genre.Type, genre);
        }

        [TestCleanup]
        public void TearDown()
        {
            CallContext.LogicalSetData(LMS.Domain.Consts.DBCONTEXT_KEY, null);
            _dbContext.Object.Dispose();
        }



    }
}
