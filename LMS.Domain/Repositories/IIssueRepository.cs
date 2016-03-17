using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IIssueRepository
    {
        Issue GetIssueDetails(int bookId);
    }
}
