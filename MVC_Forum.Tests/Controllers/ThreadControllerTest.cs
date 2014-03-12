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
        public void ThreadIndexReturnsThreadsForGivenForumId()
        {
            // Arrange
            var threadRepository = Mock.Create<IThreadRepository>();
            Mock.Arrange(() => threadRepository.GetThreads())
                .Returns(new List<Thread>() {
                    new Thread { ThreadId = 1, Title = "Test general thread", DateCreated = DateTime.Today, ForumId = 1 },
                    new Thread { ThreadId = 2, Title = "I like pancakes", DateCreated = DateTime.Today.AddDays(-2), ForumId = 1 },
                    new Thread { ThreadId = 3, Title = "Gaming thread", DateCreated = DateTime.Today.AddDays(-1), ForumId = 2 }
                }).MustBeCalled();

            // Act
            ThreadController controller = new ThreadController(threadRepository);
            ViewResult viewResult = controller.Index(1);
            var model = viewResult.Model as IEnumerable<Thread>;

            // Assert
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void ThreadsShouldBeOrderedByDateCreatedDescending()
        {
            // Arrange
            var threadRepository = Mock.Create<IThreadRepository>();
            Mock.Arrange(() => threadRepository.GetThreads())
                .Returns(new List<Thread>() {
                    new Thread { ThreadId = 1, Title = "Test general thread", DateCreated = DateTime.Today, ForumId = 1 },
                    new Thread { ThreadId = 2, Title = "I like pancakes", DateCreated = DateTime.Today.AddDays(-2), ForumId = 1 },
                    new Thread { ThreadId = 3, Title = "Pizza is delicious", DateCreated = DateTime.Today.AddDays(-1), ForumId = 1 }
                }).MustBeCalled();

            // Act
            ThreadController controller = new ThreadController(threadRepository);
            ViewResult viewResult = controller.Index(1);
            var model = viewResult.Model as IEnumerable<Thread>;

            // Assert
            Assert.AreEqual("Test general thread", model.ToList()[0].Title);
            Assert.AreEqual("Pizza is delicious", model.ToList()[1].Title);
            Assert.AreEqual("I like pancakes", model.ToList()[2].Title);
        }

        [TestMethod]
        public void ForumTitleShouldBeInViewBag()
        {
            // Arrange
            var threadRepository = Mock.Create<IThreadRepository>();
            Mock.Arrange(() => threadRepository.GetForum(1))
                .Returns(new Forum { ForumId = 1, Title = "General Forum", Description = "Blah blah", Sequence = 1 })
                .MustBeCalled();

            // Act
            ThreadController controller = new ThreadController(threadRepository);
            ViewResult viewResult = controller.Index(1);
            var expectedResult = "General Forum";

            // Assert
            Assert.AreEqual(expectedResult, viewResult.ViewBag.ForumTitle);
        }
    }
}
