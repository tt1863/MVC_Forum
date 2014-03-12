using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Forum.DAL;
using MVC_Forum.Models;

namespace MVC_Forum.Controllers
{
    public class ThreadController : Controller
    {
        private IThreadRepository threadRepository;

        public ThreadController()
        {
            this.threadRepository = new ThreadRepository(new MVC_ForumsContext());
        }

        public ThreadController(IThreadRepository threadRepository)
        {
            this.threadRepository = threadRepository;
        }

        public ViewResult Index(int forumId)
        {
            var threads = threadRepository.GetThreads()
                .Where(t => t.ForumId == forumId)
                .OrderByDescending(t => t.DateCreated);
            return View(threads);
        }
	}
}