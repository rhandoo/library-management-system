using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;
using LMS.Web.Models;

namespace LMS.Web.Controllers.ModelBuilders
{
    public interface IStockDtoBuilder
    {
        StockDto Build(Stock stock);
    }
}
