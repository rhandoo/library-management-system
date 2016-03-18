using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMS.Domain.Entities;
using LMS.Web.Models;

namespace LMS.Web.Controllers.ModelBuilders
{
    public class IssueDtoBuilder : IIssueDtoBuilder
    {
        public IssueDto Build(Issue issue)
        {
            var issueDto = new IssueDto();
            if (issue != null)
            {
                issueDto.comments = issue.Comments;
                issueDto.IssueDate = issue.IssueDate;
                issueDto.IssuedTo = issue.IssuedTo;
            }

            return issueDto;
        }
    }
}