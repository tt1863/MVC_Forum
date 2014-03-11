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
    public class ForumControllerTest
    {
        [TestMethod]
        public void IndexShouldReturnAllOfForums()
        {
            // Arrange
            var forumRepository = Mock.Create<IForumRepository>();
            Mock.Arrange(() => forumRepository.GetForums())
                .Returns(new List<Forum>() {
                    new Forum { ForumId = 1, Title = "General Forum", Description = "Place to discuss general stuff", Sequence = 1 },
                    new Forum { ForumId = 2, Title = "Gaming", Description = "Let's talk about gaming", Sequence = 2 }
                }).MustBeCalled();

            // Act
            ForumController controller = new ForumController(forumRepository);
            ViewResult viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<Forum>;

            // Assert
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void ForumsShouldBeOrderedBySequence()
        {
            // Arrange
            var forumRepository = Mock.Create<IForumRepository>();
            Mock.Arrange(() => forumRepository.GetForums())
                .Returns(new List<Forum>() {
                    new Forum { ForumId = 1, Title = "General Forum", Description = "Place to discuss general stuff", Sequence = 2 },
                    new Forum { ForumId = 2, Title = "Gaming", Description = "Let's talk about gaming", Sequence = 1 },
                    new Forum { ForumId = 3, Title = "Web Development", Description = "ASP.NET is pretty cool", Sequence = 3 }
                }).MustBeCalled();

            // Act
            ForumController controller = new ForumController(forumRepository);
            ViewResult viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<Forum>;
            model.OrderBy(f => f.Sequence);

            // Assert
            Assert.AreEqual("Gaming", model.ToList()[0].Title);
            Assert.AreEqual("General Forum", model.ToList()[1].Title);
            Assert.AreEqual("Web Development", model.ToList()[2].Title);
        }
    }
}
