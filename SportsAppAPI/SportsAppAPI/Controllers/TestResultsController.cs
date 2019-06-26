using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAppAPI.Models;

namespace SportsAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultsController : ControllerBase
    {
        private readonly TestContext _context;

        public TestResultsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/TestResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestResult>>> GetTestResults()
        {
            return await _context.TestResults.ToListAsync();
        }

        // GET: api/TestResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TestResult>>> GetTestResult(int id)
        {
            //var testResult = await _context.TestResults.FindAsync(id);
            var testResult = from t in _context.TestResults
                             .Where(t=>t.TestId==id)
                             select new TestResult
                             (t.TestResultId, t.AthleteName, t.TestId, t.Distance, t.Rating);
            if (testResult == null)
            {
                return NotFound();
            }

            return await testResult.ToListAsync();
        }
        //GET: api/TestResults/GetAthelete/2/23
        //[HttpGet("[action]/{trid}/{tid}")]
        //public async Task<ActionResult<IEnumerable<TestResult>>> GetAthelete(int trid, int tid)
        //{
        //    var testResult = await _context.TestResults.FindAsync(id);
        //    var testResult = from t in _context.TestResults
        //                     .Where(t => t.TestId == tid)
        //                     .Where(t => t.TestResultId == trid)
        //                     select new TestResult
        //                     (t.TestResultId, t.AthleteName, t.TestId, t.Distance, t.Rating);
        //    return await testResult.ToListAsync();
        //}

        // PUT: api/TestResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestResult(int id, TestResult testResult)
        {

            if (testResult.Distance <= 1000)
                testResult.Rating = "Below Average";
            else if (testResult.Distance > 1000 && testResult.Distance <= 2000)
                testResult.Rating = "Average";
            else if (testResult.Distance > 2000 && testResult.Distance <= 3500)
                testResult.Rating = "Good";
            else
                testResult.Rating = "Very Good";

            if (id != testResult.TestResultId)
            {
                return BadRequest();
            }

            _context.Entry(testResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestResultExists(id))
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

        // POST: api/TestResults
        [HttpPost]
        public async Task<ActionResult<TestResult>> PostTestResult(TestResult testResult)
        {
            if (testResult.Distance <= 1000)
                testResult.Rating = "Below Average";
            else if (testResult.Distance > 1000 && testResult.Distance<=2000)
                testResult.Rating = "Average";
            else if (testResult.Distance > 2000 && testResult.Distance <= 3500)
                testResult.Rating = "Good";
            else
                testResult.Rating = "Very Good";

            _context.TestResults.Add(testResult);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTestResult", new { id = testResult.TestResultId }, testResult);
        }

        // DELETE: api/TestResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestResult>> DeleteTestResult(int id)
        {
            var testResult = await _context.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return NotFound();
            }

            _context.TestResults.Remove(testResult);
            await _context.SaveChangesAsync();

            return testResult;
        }

        private bool TestResultExists(int id)
        {
            return _context.TestResults.Any(e => e.TestResultId == id);
        }
    }
}
