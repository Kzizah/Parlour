using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using registrationform.Data;
using registrationform.Models;

namespace registrationform.Controllers
{
    public class servicesController : Controller
    {
        private readonly DBContext _context;

        public servicesController(DBContext context)
        {
            _context = context;
        }

        // GET: services
       /* public async Task<IActionResult> Index()
        {
            return View(await _context.service.ToListAsync());
        }*/

        // GET: services/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.service
                .FirstOrDefaultAsync(m => m.id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: services/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,image,price")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: services/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // POST: services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,name,description,image,price")] Service service)
        {
            if (id != service.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!serviceExists(service.id))
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
            return View(service);
        }

        // GET: services/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.service
                .FirstOrDefaultAsync(m => m.id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var service = await _context.service.FindAsync(id);
            if (service != null)
            {
                _context.service.Remove(service);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: services
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var services = from s in _context.service select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                services = services.Where(s =>
                    s.name.Contains(searchString) ||
                    s.description.Contains(searchString));
            }

            return View(await services.ToListAsync());
        }


        private bool serviceExists(string id)
        {
            return _context.service.Any(e => e.id == id);
        }
    }
}
