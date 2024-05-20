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
    public class DVDController : Controller
    {
        private readonly ProgettoComplessoIDContext _context;

        public DVDController(ProgettoComplessoIDContext context)
        {
            _context = context;
        }

        // GET: DVD
        public async Task<IActionResult> Index()
        {
              return _context.DVD != null ? 
                          View(await _context.DVD.ToListAsync()) :
                          Problem("Entity set 'ProgettoComplessoIDContext.DVD'  is null.");
        }

        // GET: DVD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DVD == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dVD == null)
            {
                return NotFound();
            }

            return View(dVD);
        }

        // GET: DVD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DVD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titolo,Artista,Anno,Genere")] DVD dVD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dVD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dVD);
        }

        // GET: DVD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DVD == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVD.FindAsync(id);
            if (dVD == null)
            {
                return NotFound();
            }
            return View(dVD);
        }

        // POST: DVD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titolo,Artista,Anno,Genere")] DVD dVD)
        {
            if (id != dVD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dVD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DVDExists(dVD.Id))
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
            return View(dVD);
        }

        // GET: DVD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DVD == null)
            {
                return NotFound();
            }

            var dVD = await _context.DVD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dVD == null)
            {
                return NotFound();
            }

            return View(dVD);
        }

        // POST: DVD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DVD == null)
            {
                return Problem("Entity set 'ProgettoComplessoIDContext.DVD'  is null.");
            }
            var dVD = await _context.DVD.FindAsync(id);
            if (dVD != null)
            {
                _context.DVD.Remove(dVD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DVDExists(int id)
        {
          return (_context.DVD?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
