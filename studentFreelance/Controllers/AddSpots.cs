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
    public class AddSpots : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddSpots(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddSpots
        public async Task<IActionResult> Index()
        {
              return _context.spoorts != null ? 
                          View(await _context.spoorts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.spoorts'  is null.");
        }

        // GET: AddSpots/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.spoorts == null)
            {
                return NotFound();
            }

            var spoorts = await _context.spoorts
                .FirstOrDefaultAsync(m => m.sportts == id);
            if (spoorts == null)
            {
                return NotFound();
            }

            return View(spoorts);
        }

        // GET: AddSpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sportts,sport_img")] spoorts spoorts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spoorts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spoorts);
        }

        // GET: AddSpots/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.spoorts == null)
            {
                return NotFound();
            }

            var spoorts = await _context.spoorts.FindAsync(id);
            if (spoorts == null)
            {
                return NotFound();
            }
            return View(spoorts);
        }

        // POST: AddSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("sportts,sport_img")] spoorts spoorts)
        {
            if (id != spoorts.sportts)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spoorts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!spoortsExists(spoorts.sportts))
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
            return View(spoorts);
        }

        // GET: AddSpots/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.spoorts == null)
            {
                return NotFound();
            }

            var spoorts = await _context.spoorts
                .FirstOrDefaultAsync(m => m.sportts == id);
            if (spoorts == null)
            {
                return NotFound();
            }

            return View(spoorts);
        }

        // POST: AddSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.spoorts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.spoorts'  is null.");
            }
            var spoorts = await _context.spoorts.FindAsync(id);
            if (spoorts != null)
            {
                _context.spoorts.Remove(spoorts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool spoortsExists(string id)
        {
          return (_context.spoorts?.Any(e => e.sportts == id)).GetValueOrDefault();
        }
    }
}
