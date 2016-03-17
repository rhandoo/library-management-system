using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.Domain.Entities
{
    public class Issue
    {
        public int Id { get; set; }

        public string IssuedTo { get; set; }

        public string Comments { get; set; }

        public DateTime IssueDate { get; set; }
    }
}
