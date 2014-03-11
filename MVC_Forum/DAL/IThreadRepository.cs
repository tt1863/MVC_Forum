using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Forum.Models;

namespace MVC_Forum.DAL
{
    interface IThreadRepository
    {
        IEnumerable<Thread> GetThreads();
        Forum GetThreadById(int threadId);
        void CreateThread(Thread thread);
        void DeleteThread(int threadId);
        void UpdateThread(Thread thread);
    }
}
