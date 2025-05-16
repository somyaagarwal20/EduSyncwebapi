using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduSyncwebapi.Data;
using EduSyncwebapi.Models;

namespace EduSyncwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursemodelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursemodelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Coursemodels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coursemodel>>> GetCoursemodels()
        {
            return await _context.Coursemodels.ToListAsync();
        }

        // GET: api/Coursemodels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coursemodel>> GetCoursemodel(Guid id)
        {
            var coursemodel = await _context.Coursemodels.FindAsync(id);

            if (coursemodel == null)
            {
                return NotFound();
            }

            return coursemodel;
        }

        // PUT: api/Coursemodels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursemodel(Guid id, Coursemodel coursemodel)
        {
            if (id != coursemodel.Cousreld)
            {
                return BadRequest();
            }

            _context.Entry(coursemodel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursemodelExists(id))
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

        // POST: api/Coursemodels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coursemodel>> PostCoursemodel(Coursemodel coursemodel)
        {
            _context.Coursemodels.Add(coursemodel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoursemodelExists(coursemodel.Cousreld))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoursemodel", new { id = coursemodel.Cousreld }, coursemodel);
        }

        // DELETE: api/Coursemodels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursemodel(Guid id)
        {
            var coursemodel = await _context.Coursemodels.FindAsync(id);
            if (coursemodel == null)
            {
                return NotFound();
            }

            _context.Coursemodels.Remove(coursemodel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursemodelExists(Guid id)
        {
            return _context.Coursemodels.Any(e => e.Cousreld == id);
        }
    }
}
