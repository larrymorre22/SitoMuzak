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
    public class AcquistoController : Controller
    {
        private readonly ProgettoComplessoIDContext _context;

        public AcquistoController(ProgettoComplessoIDContext context)
        {
            _context = context;
        }

        // GET: Acquisto
        public async Task<IActionResult> Index()
        {
              return _context.Acquisto != null ? 
                          View(await _context.Acquisto.ToListAsync()) :
                          Problem("Entity set 'ProgettoComplessoIDContext.Acquisto'  is null.");
        }

        // GET: Acquisto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Acquisto == null)
            {
                return NotFound();
            }

            var acquisto = await _context.Acquisto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acquisto == null)
            {
                return NotFound();
            }

            return View(acquisto);
        }

        // GET: Acquisto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acquisto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAcquisto,Prodotto,Prezzo,Cliente")] Acquisto acquisto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acquisto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acquisto);
        }

        // GET: Acquisto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Acquisto == null)
            {
                return NotFound();
            }

            var acquisto = await _context.Acquisto.FindAsync(id);
            if (acquisto == null)
            {
                return NotFound();
            }
            return View(acquisto);
        }

        // POST: Acquisto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataAcquisto,Prodotto,Prezzo,Cliente")] Acquisto acquisto)
        {
            if (id != acquisto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acquisto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcquistoExists(acquisto.Id))
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
            return View(acquisto);
        }

        // GET: Acquisto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Acquisto == null)
            {
                return NotFound();
            }

            var acquisto = await _context.Acquisto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acquisto == null)
            {
                return NotFound();
            }

            return View(acquisto);
        }

        // POST: Acquisto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Acquisto == null)
            {
                return Problem("Entity set 'ProgettoComplessoIDContext.Acquisto'  is null.");
            }
            var acquisto = await _context.Acquisto.FindAsync(id);
            if (acquisto != null)
            {
                _context.Acquisto.Remove(acquisto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcquistoExists(int id)
        {
          return (_context.Acquisto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
