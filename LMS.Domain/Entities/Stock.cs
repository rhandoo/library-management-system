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

        public StockStatus Status { get; set; }

        public Issue Issue { get; set; }
    }
}
