using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentFreelance.Data;
using studentFreelance.Models;
using studentFreelance.Models.ViewModel;

namespace studentFreelance.Controllers
{
    public class AddProducts : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddProducts(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddProducts
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Products'  is null.");
        }

        // GET: AddProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.productid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: AddProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productid,productnamec,productDesc,quantity,amount,image")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: AddProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: AddProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productid,productnamec,productDesc,quantity,amount,image")] Products products)
        {
            if (id != products.productid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.productid))
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
            return View(products);
        }

        // GET: AddProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.productid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: AddProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get Items
        public async Task<IActionResult> Items()
        {
            List<Products> products = _context.Products.ToList();


            return View(products);
        }
        //Get item
        public async Task<IActionResult> item(int id)
        {
            Booking obj = new()
            {
                products = _context.Products.FirstOrDefault(c => c.productid == id)
            };
           // Products pro = _context.Products.FirstOrDefault(c => c.productid == id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> item([Bind("booking_Id,Id,product_id,type,amount,quantity,Address,payment_status")] Booking booking)
        {
           if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                _context.Add(booking);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

       

        public async Task<IActionResult> Payment()
        {
            return View();
        }


        private bool ProductsExists(int id)
        {
          return (_context.Products?.Any(e => e.productid == id)).GetValueOrDefault();
        }
    }
}
