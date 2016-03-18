using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LMS.Domain.Entities;
using Moq;
using LMS.Domain.Repositories;
using System.Runtime.Remoting.Messaging;
using LMS.Web.Controllers.ModelBuilders;
using LMS.Web.Models;
using System;

namespace LMS.Web.UnitTests
{
    [TestClass]
    public class IssueDtoBuilderUnitTests
    {
        [TestMethod]
        public void GiveIssueEntityWhenBuildThenReturnIssueDto()
        {
             //Arrange
            var issue = new Issue { Id = 1, Comments = "This book is issued to Rob", IssueDate = DateTime.Now, IssuedTo = "Rob" };

            //Act
            var issueDtoBuilder = new IssueDtoBuilder();
            var issueDto = issueDtoBuilder.Build(issue);

            //Assert
            Assert.IsNotNull(issueDto);
            Assert.AreEqual(issueDto.IssuedTo, issue.IssuedTo);
        }

        [TestMethod]
        public void GiveNullIssueEntityWhenBuildThenReturnIssueDto()
        {
            //Arrange&Act
            var issueDtoBuilder = new IssueDtoBuilder();
            var issueDto = issueDtoBuilder.Build(null);

            //Assert
            Assert.IsNull(issueDto.IssuedTo);
        }
    }
}
