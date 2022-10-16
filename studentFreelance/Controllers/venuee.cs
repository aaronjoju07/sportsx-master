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
    public class venuee : Controller
    {
        private readonly ApplicationDbContext _context;

        public venuee(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: venuee
        public async Task<IActionResult> Index()
        {
            List<venue> venuees = _context.venue.Where(a=>a.Id == User.Identity.Name).ToList();


            return View(venuees);
        }


        // GET: venuee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.venue == null)
            {
                return NotFound();
            }

            var venue = await _context.venue
                .FirstOrDefaultAsync(m => m.venue_name == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // GET: venuee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: venuee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("venue_name,Id,venue_desc,venue_pic,venue_location")] venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "AddSports");
            }
            return View(venue);
        }

        // GET: venuee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.venue == null)
            {
                return NotFound();
            }

            var venue = await _context.venue.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        // POST: venuee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("venue_name,Id,venue_desc,venue_pic,venue_location")] venue venue)
        {
            if (id != venue.venue_name)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!venueExists(venue.venue_name))
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
            return View(venue);
        }

        // GET: venuee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.venue == null)
            {
                return NotFound();
            }

            var venue = await _context.venue
                .FirstOrDefaultAsync(m => m.venue_name == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: venuee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.venue == null)
            {
                return Problem("Entity set 'ApplicationDbContext.venue'  is null.");
            }
            var venue = await _context.venue.FindAsync(id);
            if (venue != null)
            {
                _context.venue.Remove(venue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        

        private bool venueExists(string id)
        {
          return (_context.venue?.Any(e => e.venue_name == id)).GetValueOrDefault();
        }
    }
}
