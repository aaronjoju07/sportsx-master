using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentFreelance.Data;
using studentFreelance.Models;

namespace studentFreelance.Controllers
{
    public class AddTime : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddTime(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddTime
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.timmings.Include(t => t.sports);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AddTime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.timmings == null)
            {
                return NotFound();
            }

            var timming = await _context.timmings
                .Include(t => t.sports)
                .FirstOrDefaultAsync(m => m.t_Id == id);
            if (timming == null)
            {
                return NotFound();
            }

            return View(timming);
        }

        // GET: AddTime/Create
        public IActionResult Create(int? id)
        {
            //ViewBag.idd = HttpContext.Session.GetInt32("idd");
            ViewBag.idd = id;
            return View();
        }

        // POST: AddTime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("t_Id,sports_Id,s_date,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19")] timming timming)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timming);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timming);
        }

        // GET: AddTime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.timmings == null)
            {
                return NotFound();
            }

            var timming = await _context.timmings.FindAsync(id);
            if (timming == null)
            {
                return NotFound();
            }
            ViewData["sports_Id"] = new SelectList(_context.sports, "sports_Id", "sports_Id", timming.sports_Id);
            return View(timming);
        }

        // POST: AddTime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("t_Id,sports_Id,s_date,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19")] timming timming)
        {
            if (id != timming.t_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timming);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!timmingExists(timming.t_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["sports_Id"] = new SelectList(_context.sports, "sports_Id", "sports_Id", timming.sports_Id);
            return View(timming);
        }

        // GET: AddTime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.timmings == null)
            {
                return NotFound();
            }

            var timming = await _context.timmings
                .Include(t => t.sports)
                .FirstOrDefaultAsync(m => m.t_Id == id);
            if (timming == null)
            {
                return NotFound();
            }

            return View(timming);
        }

        // POST: AddTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.timmings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.timmings'  is null.");
            }
            var timming = await _context.timmings.FindAsync(id);
            if (timming != null)
            {
                _context.timmings.Remove(timming);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool timmingExists(int id)
        {
          return (_context.timmings?.Any(e => e.t_Id == id)).GetValueOrDefault();
        }
    }
}
