using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Forum.Models
{
    public class MVC_ForumsContext : DbContext
    {
        public MVC_ForumsContext()
            : base("MVC_ForumsContext")
        {

        }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}