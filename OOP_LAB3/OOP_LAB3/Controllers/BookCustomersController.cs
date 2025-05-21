using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOP_LAB3;
using OOP_LAB3.Models;

namespace OOP_LAB3.Controllers
{
    public class BookCustomersController : Controller
    {
        private readonly ApplicationContext _context;

        public BookCustomersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: BookCustomers
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.BookCustomers.Include(b => b.Book).Include(b => b.Customer);
            return View(await applicationContext.ToListAsync());
        }

        // GET: BookCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCustomer = await _context.BookCustomers
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCustomer == null)
            {
                return NotFound();
            }

            return View(bookCustomer);
        }

        // GET: BookCustomers/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            return View();
        }

        // POST: BookCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,CustomerId")] BookCustomer bookCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookCustomer.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", bookCustomer.CustomerId);
            return View(bookCustomer);
        }

        // GET: BookCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCustomer = await _context.BookCustomers.FindAsync(id);
            if (bookCustomer == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookCustomer.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", bookCustomer.CustomerId);
            return View(bookCustomer);
        }

        // POST: BookCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,CustomerId")] BookCustomer bookCustomer)
        {
            if (id != bookCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCustomerExists(bookCustomer.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id", bookCustomer.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", bookCustomer.CustomerId);
            return View(bookCustomer);
        }

        // GET: BookCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCustomer = await _context.BookCustomers
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCustomer == null)
            {
                return NotFound();
            }

            return View(bookCustomer);
        }

        // POST: BookCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCustomer = await _context.BookCustomers.FindAsync(id);
            if (bookCustomer != null)
            {
                _context.BookCustomers.Remove(bookCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCustomerExists(int id)
        {
            return _context.BookCustomers.Any(e => e.Id == id);
        }
    }
}
