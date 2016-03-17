using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Web.Models;
using LMS.Domain.Entities;

namespace LMS.Web.Controllers.ModelBuilders
{
    public class BookDtoBuilder : IBookDtoBuilder
    {
        public BookDto Build(Book book)
        {
            return new BookDto
            {
                BookId = book.Id,
                ISBNCode = book.ISBNCode,
                Author = book.Author.Name,
                Genre = book.Genre.Type,
                Title = book.Title
            };
        }
    }
}