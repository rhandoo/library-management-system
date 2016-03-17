using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Models
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string ISBNCode { get; set; }

        public string Title { get; set; }
        
        public string Genre { get; set; }

        public string Author { get; set; }
    }
}