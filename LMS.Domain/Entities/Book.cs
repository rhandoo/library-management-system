using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string ISBNCode { get; set; }

        public string Title { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }
    }
}
