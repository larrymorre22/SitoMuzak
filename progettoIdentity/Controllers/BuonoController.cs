using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgettoComplessoID.Data;
using ProgettoComplessoID.Models;

namespace ProgettoComplessoID.Controllers
{
    public class BuonoController : Controller
    {
        private readonly ProgettoComplessoIDContext _context;

        public BuonoController(ProgettoComplessoIDContext context)
        {
            _context = context;
        }

        // GET: Buono
        public async Task<IActionResult> Index()
        {
              return _context.Buono != null ? 
                          View(await _context.Buono.ToListAsync()) :
                          Problem("Entity set 'ProgettoComplessoIDContext.Buono'  is null.");
        }

        // GET: Buono/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Buono == null)
            {
                return NotFound();
            }

            var buono = await _context.Buono
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buono == null)
            {
                return NotFound();
            }

            return View(buono);
        }

        // GET: Buono/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buono/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codice,Valore,DataScadenza")] Buono buono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buono);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buono);
        }

        // GET: Buono/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Buono == null)
            {
                return NotFound();
            }

            var buono = await _context.Buono.FindAsync(id);
            if (buono == null)
            {
                return NotFound();
            }
            return View(buono);
        }

        // POST: Buono/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codice,Valore,DataScadenza")] Buono buono)
        {
            if (id != buono.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buono);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuonoExists(buono.Id))
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
            return View(buono);
        }

        // GET: Buono/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Buono == null)
            {
                return NotFound();
            }

            var buono = await _context.Buono
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buono == null)
            {
                return NotFound();
            }

            return View(buono);
        }

        // POST: Buono/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Buono == null)
            {
                return Problem("Entity set 'ProgettoComplessoIDContext.Buono'  is null.");
            }
            var buono = await _context.Buono.FindAsync(id);
            if (buono != null)
            {
                _context.Buono.Remove(buono);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuonoExists(int id)
        {
          return (_context.Buono?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
