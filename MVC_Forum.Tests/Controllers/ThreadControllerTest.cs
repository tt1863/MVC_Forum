using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_Forum;
using MVC_Forum.Controllers;
using MVC_Forum.Models;
using MVC_Forum.DAL;
using Telerik.JustMock;

namespace MVC_Forum.Tests.Controllers
{
    [TestClass]
    public class ThreadControllerTest
    {
        [TestMethod]
        public void IndexReturnsThreadsForGivenForumId()
        {
            // Arrange
            var threadRepository = Mock.Create<IThreadRepository>();
            Mock.Arrange(() => threadRepository.GetThreads(1))
                .Returns
        }
    }
}
