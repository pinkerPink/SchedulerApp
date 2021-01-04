using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    public class TaskDetailContext:DbContext
    {
        public TaskDetailContext(DbContextOptions<TaskDetailContext> options):base(options)
        {

        }

        public DbSet<TaskDetail> TaskDetails { get; set; }
    }
}
