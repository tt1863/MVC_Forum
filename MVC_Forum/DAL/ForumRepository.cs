using MVC_Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Forum.DAL
{
    public class ForumRepository : IForumRepository, IDisposable
    {
        private MVC_ForumsContext context;

        public ForumRepository(MVC_ForumsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Models.Forum> GetForums()
        {
            return context.Forums.ToList();
        }

        public Models.Forum GetForumById(int forumId)
        {
            return context.Forums.Find(forumId);
        }

        public void CreateForum(Models.Forum forum)
        {
            context.Forums.Add(forum);
        }

        public void DeleteForum(int forumId)
        {
            Forum forum = context.Forums.Find(forumId);
            context.Forums.Remove(forum);
        }

        public void UpdateForum(Models.Forum forum)
        {
            context.Entry(forum).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}