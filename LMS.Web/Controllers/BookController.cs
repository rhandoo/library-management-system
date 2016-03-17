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
    public class BookController : ApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILmsSearchDtoBuilder _lmsSearchDtoBuilder;

        public BookController()
            : this(IoC.Kernal.Get<IBookRepository>(), IoC.Kernal.Get<ILmsSearchDtoBuilder>())
        {

        }

        public BookController(IBookRepository bookRepository, ILmsSearchDtoBuilder lmsSearchDtoBuilder)
        {
            _bookRepository = bookRepository;
            _lmsSearchDtoBuilder = lmsSearchDtoBuilder;
        }

        [HttpGet]
        public HttpResponseMessage Get(string isbnCode, string author, string title)
        {
            var data = _lmsSearchDtoBuilder.GetBooks(_bookRepository.GetBooks(isbnCode, author, title));
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


    }
}