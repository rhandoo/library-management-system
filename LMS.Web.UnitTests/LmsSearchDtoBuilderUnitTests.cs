using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LMS.Domain.Entities;
using Moq;
using LMS.Domain.Repositories;
using System.Runtime.Remoting.Messaging;
using LMS.Web.Controllers.ModelBuilders;
using LMS.Web.Models;

namespace LMS.Web.UnitTests
{
    [TestClass]
    public class LmsSearchDtoBuilderUnitTests
    {

        [TestMethod]
        public void GiveBooksWhenGetBooksThenReturnBooksDto()
        {
            //Arrange
            var books = TestableBook.GetStubBooks().Where(b => b.GenreId == 2).ToList();
            var bookDtoBuilder = new Mock<IBookDtoBuilder>();
            bookDtoBuilder.Setup(x => x.Build(It.IsAny<Book>())).
                Returns(new BookDto { BookId = 1, Title = "Book1", ISBNCode = "IBGHGHGS2", Genre = "Comedy", Author = "John" });

            //Act
            var lmsSearchDtoBuilder = new LmsSearchDtoBuilder(bookDtoBuilder.Object);
            var booksDto = lmsSearchDtoBuilder.GetBooks(books);

            //Assert
            Assert.IsNotNull(booksDto);
            Assert.AreEqual(booksDto.First().Title, "Book1");
        }
    }
}
