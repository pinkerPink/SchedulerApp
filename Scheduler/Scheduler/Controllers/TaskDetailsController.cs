using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scheduler.Models;

namespace Scheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly TaskDetailContext _context;

        public TaskDetailsController(TaskDetailContext context)
        {
            _context = context;
        }

        // GET: api/TaskDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDetail>>> GetTaskDetails()
        {
            return await _context.TaskDetails.ToListAsync();
        }

        // GET: api/TaskDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetail>> GetTaskDetail(int id)
        {
            var taskDetail = await _context.TaskDetails.FindAsync(id);

            if (taskDetail == null)
            {
                return NotFound();
            }

            return taskDetail;
        }

        // PUT: api/TaskDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDetail(int id, TaskDetail taskDetail)
        {
            if (id != taskDetail.TaskDetailId)
            {
                return BadRequest();
            }

            _context.Entry(taskDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TaskDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskDetail>> PostTaskDetail(TaskDetail taskDetail)
        {
            _context.TaskDetails.Add(taskDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskDetail", new { id = taskDetail.TaskDetailId }, taskDetail);
        }

        // DELETE: api/TaskDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskDetail(int id)
        {
            var taskDetail = await _context.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            _context.TaskDetails.Remove(taskDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskDetailExists(int id)
        {
            return _context.TaskDetails.Any(e => e.TaskDetailId == id);
        }
    }
}
