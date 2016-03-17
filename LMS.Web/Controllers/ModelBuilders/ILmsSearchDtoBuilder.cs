using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Web.Models;
using LMS.Domain.Entities;

namespace LMS.Web.Controllers.ModelBuilders
{
    public interface ILmsSearchDtoBuilder
    {
        IList<BookDto> GetBooks(IList<Book> books);
    }
}
