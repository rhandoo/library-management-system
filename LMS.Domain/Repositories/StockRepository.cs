﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;
using System.Data;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace LMS.Domain.Repositories
{
    public class StockRepository : IStockRepository
    {
        public Stock GetBookStock(int bookId)
        {
            return DbContext().Stock.Single(b => b.Book.Id == bookId);
        }


        private LmsDbContext DbContext()
        {
            return (LmsDbContext)CallContext.LogicalGetData(Consts.DBCONTEXT_KEY);
        }
    }
}