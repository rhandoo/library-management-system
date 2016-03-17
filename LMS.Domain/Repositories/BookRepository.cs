using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;
using System.Data;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace LMS.Domain.Repositories
{
    public class BookRepository : IBookRepository
    {
        public IList<Book> GetBooks(string isbnCode, string title, string genre, string author)
        {
            var books = (from a in DbContext().Book
                                .Include(y => y.Author)
                                .Include(y => y.Genre)
                         select a);

            if (!String.IsNullOrEmpty(isbnCode))
            {
                books = books.Where(b => b.ISBNCode == isbnCode);
            }

            if (!String.IsNullOrEmpty(title))
            {
                books = books.Where(b => b.Title == title);
            }

            if (!String.IsNullOrEmpty(author))
            {
                books = books.Where(b => b.Author.Name == author);
            }

            if (!String.IsNullOrEmpty(genre))
            {
                books = books.Where(b => b.Genre.Type == genre);
            }

            return books.OrderByDescending(x => x.Title).ToList();
        }

        public Book GetBook(int bookId)
        {
            return DbContext().Book.Single(b => b.Id == bookId);
        }

        private LmsDbContext DbContext()
        {
            return (LmsDbContext)CallContext.LogicalGetData(Consts.DBCONTEXT_KEY);
        }

    }
}
