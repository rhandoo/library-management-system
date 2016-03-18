using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace LMS.Domain
{
    public enum StockStatus
    {
        [Description("OnShelf")]
        InStock = 1,

        [Description("OutOnLoan")]
        Issued = 2
    }
}
