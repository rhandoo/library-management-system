using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using LMS.Web.Models;
using LMS.Domain.Entities;

namespace LMS.Web.Controllers.ModelBuilders
{
    public class LmsSearchDtoBuilder : ILmsSearchDtoBuilder
    {
        private readonly IBookDtoBuilder _bookDtoBuilder;
        public LmsSearchDtoBuilder(IBookDtoBuilder bookDtoBuilder)
        {
            _bookDtoBuilder = bookDtoBuilder;
        }

        public LmsSearchDtoBuilder()
            : this(IoC.Kernal.Get<IBookDtoBuilder>())
        {
        }


        public IList<BookDto> GetBooks(IList<Book> books)
        {
            var booksDto = new List<BookDto>(); 

            foreach(var book in books)
            {
                booksDto.Add(_bookDtoBuilder.Build(book));
            }

            return booksDto;
        }
    }
}