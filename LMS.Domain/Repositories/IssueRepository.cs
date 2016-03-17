using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;
using System.Data;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace LMS.Domain.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        public Issue GetIssueDetails(int bookId)
        {
            return
                (from a in DbContext().Stock
                          .Include(y => y.Issue)
                 select a).Where(s => s.Book.Id == bookId).First().Issue;

        }

        private LmsDbContext DbContext()
        {
            return (LmsDbContext)CallContext.LogicalGetData(Consts.DBCONTEXT_KEY);
        }
    }
}
