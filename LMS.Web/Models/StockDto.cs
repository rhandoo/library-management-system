using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Models
{
    public class StockDto
    {
        public BookDto BookDto { get; set; }
        
        public string StockStatus { get; set; }
        
        public IssueDto IssueDto { get; set; }
    }
}