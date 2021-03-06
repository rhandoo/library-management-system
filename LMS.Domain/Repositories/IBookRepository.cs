﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IBookRepository
    {
        IList<Book> GetBooks(string isbnCode, string title, string genre, string author);
        Book GetBook(int bookId);
    }
}
