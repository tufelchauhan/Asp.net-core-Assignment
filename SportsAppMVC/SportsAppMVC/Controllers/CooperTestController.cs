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
    public class CooperTestController : Controller
    {
        private readonly TestContext _context;

        public CooperTestController(TestContext context)
        {
            _context = context;
        }

        // GET: CooperTest
        public async Task<IActionResult> Index()
        {
            return View(await _context.CooperTests.ToListAsync());
        }

        // GET: CooperTest/Create
        public IActionResult AddorEdit(int id=0)
        {
            if (id == 0)
                return View(new CooperTest());
            else
                return View(_context.CooperTests.Find(id));
        }

        // POST: CooperTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("TestID,TestName")] CooperTest cooperTest)
        {
            if (ModelState.IsValid)
            {
                if(cooperTest.TestID==0)
                    _context.Add(cooperTest);
                else
                    _context.Update(cooperTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cooperTest);
        }

        // GET: CooperTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var test = await _context.CooperTests.FindAsync(id);
            _context.CooperTests.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
