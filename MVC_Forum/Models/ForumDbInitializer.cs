﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Forum.Models
{
    public class ForumDbInitializer : DropCreateDatabaseAlways<MVC_ForumsContext>
    {
        protected override void Seed(MVC_ForumsContext context)
        {
            context.Forums.Add(new Forum { ForumId = 1, Title = "General Forum", Description = "Place to talk about general stuff", Sequence = 1 });
            context.Forums.Add(new Forum { ForumId = 2, Title = "Gaming", Description = "Let's talk about games", Sequence = 2 });
            context.Forums.Add(new Forum { ForumId = 3, Title = "Web Development", Description = "ASP.NET MVC is pretty cool", Sequence = 3 });
            context.Forums.Add(new Forum { ForumId = 4, Title = "Motorcycles", Description = "What kind of bike do you ride?", Sequence = 4 });

            context.Threads.Add(new Thread
                {
                    ThreadId = 1,
                    ForumId = 1,
                    Title = "Test general thread",
                    DateCreated = DateTime.Now
                });

            context.Threads.Add(new Thread
            {
                ThreadId = 2,
                ForumId = 1,
                Title = "Test gaming thread",
                DateCreated = DateTime.Now
            });

            context.Threads.Add(new Thread
            {
                ThreadId = 3,
                ForumId = 2,
                Title = "I like League of Legends",
                DateCreated = DateTime.Now
            });

            base.Seed(context);
        }
    }
}