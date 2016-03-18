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
    public class StockRepositoryTests
    {
        private Mock<LmsDbContext> _dbContext;

        [TestInitialize]
        public void Setup()
        {
            _dbContext = new Mock<LmsDbContext>();

            CallContext.LogicalSetData(LMS.Domain.Consts.DBCONTEXT_KEY, _dbContext.Object);
        }

        [TestMethod]
        public void GivenBookIdWhenGetBookStockThenReturnBookStockDetails()
        {
            //Arrange
            int bookid = 1;
            var dbSetMock = TestableBook.GetDbSetMock<Stock>(TestableBook.GetStubBookStock().AsQueryable());
            _dbContext.Setup(x => x.Stock ).Returns(dbSetMock.Object);

            //Act
            var stockRepository = new StockRepository();
            var bookStock = stockRepository.GetBookStock(bookid);

            //Assert
            Assert.IsNotNull(bookStock);
            Assert.AreEqual(bookStock.BookId, bookid);
        }

        [TestCleanup]
        public void TearDown()
        {
            CallContext.LogicalSetData(LMS.Domain.Consts.DBCONTEXT_KEY, null);
            _dbContext.Object.Dispose();
        }



    }
}
