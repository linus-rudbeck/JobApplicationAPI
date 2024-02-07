using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApplicationAPI.Data;
using JobApplicationAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly JobApplicationContext _context;

        public ApplicationsController(JobApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Applications
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplication()
        {
            return await _context.Applications.Include(x => x.Job).ToListAsync();
        }

        // GET: api/Applications/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _context.Applications.Include(x => x.Job).FirstOrDefaultAsync(x => x.Id == id);

            if (application == null)
            {
                return NotFound();
            }

            return application;
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: api/Applications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            application.Job = await _context.Jobs.FindAsync(application.JobId);
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
