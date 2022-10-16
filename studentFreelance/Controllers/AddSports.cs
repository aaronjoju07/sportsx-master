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
    public class AddSports : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddSports(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddSports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.sports.Include(s => s.spoorts).Include(s => s.venue);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AddSports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sports == null)
            {
                return NotFound();
            }

            var sports = await _context.sports
                .Include(s => s.spoorts)
                .Include(s => s.venue)
                .FirstOrDefaultAsync(m => m.sports_Id == id);
            if (sports == null)
            {
                return NotFound();
            }

            return View(sports);
        }

        // GET: AddSports/Create
        public IActionResult Create()
        {
            ViewData["sportts"] = new SelectList(_context.spoorts, "sportts", "sportts");
            ViewData["venue_name"] = new SelectList(_context.venue, "venue_name", "venue_name");
            return View();
        }

        // POST: AddSports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sports_Id,venue_name,sportts,slot_name,amount,userid")] sports sports)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(sports);
                await _context.SaveChangesAsync();
                //HttpContext.Session.Set("idd", sports.sports_Id);
                return RedirectToAction("Create", "AddTime", new { id = sports.sports_Id });
                //return RedirectToAction("Create", "AddTime");
            }
            ViewData["sportts"] = new SelectList(_context.spoorts, "sportts", "sportts", sports.sportts);
            ViewData["venue_name"] = new SelectList(_context.venue, "venue_name", "venue_name", sports.venue_name);
            return View(sports);
        }

        // GET: AddSports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sports == null)
            {
                return NotFound();
            }

            var sports = await _context.sports.FindAsync(id);
            if (sports == null)
            {
                return NotFound();
            }
            ViewData["sportts"] = new SelectList(_context.spoorts, "sportts", "sportts", sports.sportts);
            ViewData["venue_name"] = new SelectList(_context.venue, "venue_name", "venue_name", sports.venue_name);
            return View(sports);
        }

        // POST: AddSports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sports_Id,venue_name,sportts,slot_name,amount,userid")] sports sports)
        {
            if (id != sports.sports_Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(sports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sportsExists(sports.sports_Id))
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
            ViewData["sportts"] = new SelectList(_context.spoorts, "sportts", "sportts", sports.sportts);
            ViewData["venue_name"] = new SelectList(_context.venue, "venue_name", "venue_name", sports.venue_name);
            return View(sports);
        }

        // GET: AddSports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sports == null)
            {
                return NotFound();
            }

            var sports = await _context.sports
                .Include(s => s.spoorts)
                .Include(s => s.venue)
                .FirstOrDefaultAsync(m => m.sports_Id == id);
            if (sports == null)
            {
                return NotFound();
            }

            return View(sports);
        }

        // POST: AddSports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sports == null)
            {
                return Problem("Entity set 'ApplicationDbContext.sports'  is null.");
            }
            var sports = await _context.sports.FindAsync(id);
            if (sports != null)
            {
                _context.sports.Remove(sports);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sportsExists(int id)
        {
          return (_context.sports?.Any(e => e.sports_Id == id)).GetValueOrDefault();
        }
    }
}
