using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LMS.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        public Book Book { get; set; }

        public int StatusId { get; set; }

        public StockStatus Status { get { return StatusId == 1 ? StockStatus.InStock : StockStatus.Issued; } }

        public Issue Issue { get; set; }

        public int IssueId { get; set; }

        public int BookId { get; set; }
    }
}
