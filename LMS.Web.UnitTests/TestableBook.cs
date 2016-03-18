using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LMS.Domain.Entities;
using Moq;
using LMS.Domain.Repositories;
using System;

namespace LMS.Web.UnitTests
{
    public static class TestableBook
    {
        public static IList<Book> GetStubBooks()
        {
            IList<Book> books = new List<Book> {
                new Book{ Id =1, Title="Book1",ISBNCode="Ib1234567",AuthorId=1,Author = GetStubAuthor(1),GenreId=1,Genre=GetStubGenre(1) },
            new Book{ Id =2, Title="Book2",ISBNCode="Ib12343267",AuthorId=2,Author = GetStubAuthor(2),GenreId=2,Genre=GetStubGenre(2) },
            new Book{ Id =3, Title="Book3",ISBNCode="Ib12323457",AuthorId=3,Author = GetStubAuthor(3),GenreId=3,Genre=GetStubGenre(3) },
            new Book{ Id =4, Title="Book4",ISBNCode="Ib1234908t",AuthorId=4,Author = GetStubAuthor(4),GenreId=4,Genre=GetStubGenre(4) },
            new Book{ Id =5, Title="Book5",ISBNCode="Ib122323m98",AuthorId=1,Author = GetStubAuthor(1),GenreId=3,Genre=GetStubGenre(3) },
            new Book{ Id =6, Title="Book6",ISBNCode="Ib12asdkMKJH",AuthorId=1,Author = GetStubAuthor(1),GenreId=2,Genre=GetStubGenre(2) },
            new Book{ Id =7, Title="Book7",ISBNCode="IbHJUYY78",AuthorId=1,Author = GetStubAuthor(1),GenreId=4,Genre=GetStubGenre(4) }
            };

            return books;

        }


        public static IList<Stock> GetStubBookStock()
        {
            IList<Stock> books = new List<Stock> {
                new Stock{ Id =1, BookId=1, Book = GetStubBook(1),StatusId=1 },
                 new Stock{ Id =2, BookId=2, Book = GetStubBook(2),StatusId=1 },
                  new Stock{ Id=3, BookId=3, Book = GetStubBook(3),StatusId=2,IssueId=1,Issue = new Issue{IssuedTo="John",IssueDate=DateTime.Now,Id=1} }
           
            };

            return books;

        }

        public static Book GetStubBook(int bookId)
        {
            return GetStubBooks().First(f => f.Id == bookId);
        }


        public static Author GetStubAuthor(int authorId)
        {
            return GetStubAuthors().First(f => f.Id == authorId);
        }

        public static IList<Author> GetStubAuthors()
        {
            IList<Author> authors = new List<Author> { 
            new Author{Id=1, Name="John"},
            new Author{Id=2, Name="Rob"},
            new Author{Id=3, Name="Steve"},
            new Author{Id=4, Name="Neil"}
            };
            return authors;
        }

        public static IList<Genre> GetStubGenres()
        {
            IList<Genre> authors = new List<Genre> { 
            new Genre{Id=1, Type="Comedy"},
            new Genre{Id=2, Type="History"},
            new Genre{Id=3, Type="Action"},
            new Genre{Id=4, Type="Sports"}
            };
            return authors;
        }

        public static Genre GetStubGenre(int genreId)
        {
            return GetStubGenres().First(f => f.Id == genreId);
        }
    }
}
