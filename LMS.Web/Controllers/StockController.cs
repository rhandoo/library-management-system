using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LMS.Web.Models;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using LMS.Web.Controllers.ModelBuilders;
using Ninject;
using LMS.Domain;
using LMS.Web.Filters;


namespace LMS.Web.Controllers
{
    [LMSDbContextFilter(typeof(LmsDbContext))]
    public class StockController : ApiController
    {
        private readonly IStockRepository _stockRepository;
        private readonly IStockDtoBuilder _stockDtoBuilder;

        public StockController()
            : this(IoC.Kernal.Get<IStockRepository>(), IoC.Kernal.Get<IStockDtoBuilder>())
        { }

        public StockController(IStockRepository stockRepository, IStockDtoBuilder stockDtoBuilder)
        {
            _stockRepository = stockRepository;
            _stockDtoBuilder = stockDtoBuilder;
        }

        [HttpGet]
        public HttpResponseMessage Get(int bookId)
        {
            var data = _stockDtoBuilder.Build(_stockRepository.GetBookStock(bookId));
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Issue(int stockId, string issuedTo, string comments)
        {
             return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Deposit(int stockId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
