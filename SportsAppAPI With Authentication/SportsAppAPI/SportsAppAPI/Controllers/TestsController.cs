using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAppAPI.Models;

namespace SportsAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestContext _context;

        public TestsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/Tests
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<TestsList>>> GetTests()
        {
            var query = from t in _context.Tests
                        join tr in _context.TestResults on t.TestId equals tr.TestId
                        into tmp
                        select new TestsList
                        {
                            TestId = t.TestId,
                            TestDate = t.TestDate,
                            TestType = t.TestType,
                            ParticipantsCount = t != null ? _context.TestResults.Count(n => n.TestId == t.TestId) : 0
                        };
            return await query.ToListAsync();
            //return await _context.Tests.ToListAsync();
        }

        // GET: api/Tests/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        // PUT: api/Tests/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.TestId)
            {
                return BadRequest();
            }

            _context.Entry(test).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Tests
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTest", new { id = test.TestId }, test);
        }

        // DELETE: api/Tests/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Test>> DeleteTest(int id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            //var tmp = from t in _context.TestResults
            //          where t.TestId == id
            //          select new TestResult(t.TestResultId, t.AthleteName, t.TestId, t.Distance, t.Rating);
            var tmp = _context.TestResults.Where(q => q.TestId == id);
            _context.TestResults.RemoveRange(tmp);
            await _context.SaveChangesAsync();
            return test;
        }

        private bool TestExists(int id)
        {
            return _context.Tests.Any(e => e.TestId == id);
        }
    }
}
