using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using LMS.Web.Controllers;
using LMS.Web.Controllers.ModelBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using LMS.Web.Models;
using System.Linq;
using System.Web.Http.Hosting;
using System.Net;

namespace LMS.Web.UnitTests
{
    [TestClass]
    public class BookControllerUnitTests
    {
        [TestMethod]
        public void GiveSearchRequestWhenGenThenReturnBooksDto()
        {
            // Arrange
            var builder = new Mock<ILmsSearchDtoBuilder>();
            var bookRepository = new Mock<IBookRepository>();
            var books = TestableBook.GetStubBooks().Where(b => b.GenreId == 2).ToList();
            builder.Setup(x => x.GetBooks(It.IsAny<IList<Book>>())).Returns(new List<BookDto>() { new BookDto { BookId = 1, Author = "Rob", Genre = "Comedy", ISBNCode = "IB67627623GH", Title = "Book1" } });
            bookRepository.Setup(x => x.GetBooks(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(books);
            var bookController = new BookController(bookRepository.Object, builder.Object);
            bookController.Request = new HttpRequestMessage();
            bookController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            //Act
            var response = bookController.Get("", "", "", "");

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
 
        }
    }
}
