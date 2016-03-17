using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Web.Models
{
    public class IssueDto
    {
        public string IssuedTo { get; set; }

        public DateTime IssueDate { get; set; }

        public string comments { get; set; }
    }
}