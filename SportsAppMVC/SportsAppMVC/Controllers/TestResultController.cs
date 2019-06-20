using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsAppMVC.Models;

namespace SportsAppMVC.Controllers
{
    public class TestResultController : Controller
    {
        private readonly TestContext _context;

        public TestResultController(TestContext context)
        {
            _context = context;
        }

        // GET: TestResult
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestResults.ToListAsync());
        }

        // GET: TestResult/Create
        public IActionResult AddorEdit(int id=0)
        {
            if (id == 0)
                return View(new TestResult());
            else
                return View(_context.TestResults.Find(id));
        }

        // POST: TestResult/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("ResultId,UserId,TestId,Points")] TestResult testResult)
        {
            if (ModelState.IsValid)
            {
                if(testResult.ResultId==0)
                    _context.Add(testResult);
                else
                    _context.Update(testResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testResult);
        }

        // GET: TestResult/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var testresult = await _context.TestResults.FindAsync(id);
            _context.TestResults.Remove(testresult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
