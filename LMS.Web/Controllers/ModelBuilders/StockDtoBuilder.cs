using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using LMS.Web.Models;
using LMS.Domain.Entities;

namespace LMS.Web.Controllers.ModelBuilders
{
    public class StockDtoBuilder : IStockDtoBuilder
    {
       private readonly IBookDtoBuilder _bookDtoBuilder;
       private readonly IIssueDtoBuilder _issueDtoBuilder;

        public StockDtoBuilder(IBookDtoBuilder bookDtoBuilder, IIssueDtoBuilder issueDtoBuilder)
        {
            _bookDtoBuilder = bookDtoBuilder;
            _issueDtoBuilder = issueDtoBuilder;
        }

        public StockDtoBuilder()
            : this(IoC.Kernal.Get<IBookDtoBuilder>(), IoC.Kernal.Get<IIssueDtoBuilder>())
        {
        }


        public StockDto Build(Stock stock)
        {
            var stockDto = new StockDto {
                BookDto = _bookDtoBuilder.Build(stock.Book),
                IssueDto = _issueDtoBuilder.Build(stock.Issue),
                StockStatus = stock.Status.ToString(),
                IsIssued = stock.Status == Domain.StockStatus.Issued
            };
            return stockDto;
        }
    }
}