using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    public class TaskDetail
    {
        [Key]
        public int TaskDetailId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string TaskDescription { get; set; }
    }
}
