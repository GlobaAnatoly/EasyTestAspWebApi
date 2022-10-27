using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTestApi.Models;

namespace WebTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsTestsController : ControllerBase
    {
        private readonly TestDbContext _context;

        public StudentsTestsController(TestDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentsTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsTest>>> GetStudentsTests()
        {
            return await _context.StudentsTests.ToListAsync();
        }

        // GET: api/StudentsTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsTest>> GetStudentsTest(int id)
        {
            var studentsTest = await _context.StudentsTests.FindAsync(id);

            if (studentsTest == null)
            {
                return NotFound();
            }

            return studentsTest;
        }

        // PUT: api/StudentsTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentsTest(int id, StudentsTest studentsTest)
        {
            if (id != studentsTest.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentsTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsTestExists(id))
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

        // POST: api/StudentsTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsTest>> PostStudentsTest(StudentsTest studentsTest)
        {
            _context.StudentsTests.Add(studentsTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentsTest", new { id = studentsTest.Id }, studentsTest);
        }

        // DELETE: api/StudentsTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentsTest(int id)
        {
            var studentsTest = await _context.StudentsTests.FindAsync(id);
            if (studentsTest == null)
            {
                return NotFound();
            }

            _context.StudentsTests.Remove(studentsTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentsTestExists(int id)
        {
            return _context.StudentsTests.Any(e => e.Id == id);
        }
    }
}
