using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Forum.DAL;
using MVC_Forum.Models;

namespace MVC_Forum.Controllers
{
    public class ForumController : Controller
    {
        private IForumRepository forumRepository;

        public ForumController()
        {
            this.forumRepository = new ForumRepository(new MVC_ForumsContext());
        }

        public ForumController(IForumRepository forumRepository)
        {
            this.forumRepository = forumRepository;
        }

        public ViewResult Index()
        {
            var forums = forumRepository.GetForums().OrderBy(f => f.Sequence);
            return View(forums);
        }
	}
}