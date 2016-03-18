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
    public class StockDtoBuilderUnitTests
    {
        [TestMethod]
        public void GiveStockEntityWhenBuildThenReturnStockDto()
        {
            //Arrange
            var stock = TestableBook.GetStubBookStock().FirstOrDefault(b => b.Id == 1);
            var bookDtoBuilder = new Mock<IBookDtoBuilder>();
            bookDtoBuilder.Setup(x => x.Build(It.IsAny<Book>())).
                Returns(new BookDto { BookId = 1, Title = "Book1", ISBNCode = "IBGHGHGS2", Genre = "Comedy", Author = "John" });
            var issueDtoBuilder = new Mock<IIssueDtoBuilder>();

            //Act
            var stockDtoBuilder = new StockDtoBuilder(bookDtoBuilder.Object, issueDtoBuilder.Object);
            var bookStockDto = stockDtoBuilder.Build(stock);

            //Assert
            Assert.IsNotNull(bookStockDto);
            Assert.AreEqual(bookStockDto.BookDto.Title, stock.Book.Title);
        }
    }
}
