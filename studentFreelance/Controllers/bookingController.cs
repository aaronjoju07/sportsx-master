using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentFreelance.Data;
using studentFreelance.Models;


namespace studentFreelance.Controllers
{
    public class bookingController : Controller
    {
        private readonly ApplicationDbContext _context;
      
      

        public bookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: booking
        public async Task<IActionResult> Index()
        {
             List<venue> venuees = _context.venue.ToList();
            

            return View(venuees);
        }

        // GET: booking/Details/5
        public async Task<IActionResult> Details(string id, int? spo = null)
        {

            if (spo != null)
            {

            }
            venue ven = _context.venue.Include(a => a.Sports.Where(s => s.venue_name == id)).FirstOrDefault(c => c.venue_name == id);
           
                       
            
            return View(ven);
            

        }
        public async Task<IActionResult> tim(int id)        {
            var applicationDbContext = _context.timmings.Include(t => t.sports).Where(a=>a.sports_Id == id);
            return View(await applicationDbContext.ToListAsync());
        }
        public JsonResult ti(int id)
        {
            id = 1;
            timming timming = _context.timmings.Where(a => a.sports_Id == id).FirstOrDefault();
            return new JsonResult(timming);
        }
        public async Task<IActionResult> Edittime(int? id)
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
        public async Task<IActionResult> Edittime(int id, [Bind("t_Id,sports_Id,s_date,s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12,s13,s14,s15,s16,s17,s18,s19")] timming timming)
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
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["sports_Id"] = new SelectList(_context.sports, "sports_Id", "sports_Id", timming.sports_Id);
            return View(timming);
        }

        //private bool timmingExists(int t_Id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(Booking sports)
        {
            
            
                //var bk = new Booking()
                //{
                //    venue_name = sports.venue_name,
                //    Id = User.Identity?.Name,
                //    sports_Id = sports.sports_Id,
                //    t_Id = 1,
                //    type = false,
                //    amount = sports.amount,
                //    quantity = 1,
                //    payment_status = false
                //};
                //_context.Bookings.Add(bk);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

            return View(sports);
        }

        // GET: booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: booking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        


        //// GET: venuee/Create
        //public IActionResult Add()
        //{
        //    venue venue = new venue();
        //    venue.Sports.Add(new sports() { sports_Id = 1 });
        //    return View();
        //}

        //// POST: venuee/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add(venue venue)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //foreach(sports sports in venue.Sports)
        //        //{

        //        //}
        //        _context.Add(venue);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(venue);
        //}
    }
}