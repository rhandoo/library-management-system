using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IStockRepository
    {
        Stock GetBookStock(int bookId);
    }
}
