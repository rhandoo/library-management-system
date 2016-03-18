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
    public class BookDtoBuilderUnitTests
    {

        [TestMethod]
        public void GiveBookWhenBuildThenReturnBookDto()
        {
            //Arrange
            var book = TestableBook.GetStubBooks().FirstOrDefault(b => b.GenreId == 2);

            //Act
            var bookDtoBuilder = new BookDtoBuilder();
            var bookDto = bookDtoBuilder.Build(book);

            //Assert
            Assert.IsNotNull(bookDto);
            Assert.AreEqual(bookDto.Genre, book.Genre.Type);
        }
    }
}
