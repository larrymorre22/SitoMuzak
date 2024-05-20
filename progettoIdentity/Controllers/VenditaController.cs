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
    public class VenditaController : Controller
    {
        private readonly ProgettoComplessoIDContext _context;

        public VenditaController(ProgettoComplessoIDContext context)
        {
            _context = context;
        }

        // GET: Vendita
        public async Task<IActionResult> Index()
        {
              return _context.Vendita != null ? 
                          View(await _context.Vendita.ToListAsync()) :
                          Problem("Entity set 'ProgettoComplessoIDContext.Vendita'  is null.");
        }

        // GET: Vendita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendita == null)
            {
                return NotFound();
            }

            var vendita = await _context.Vendita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendita == null)
            {
                return NotFound();
            }

            return View(vendita);
        }

        // GET: Vendita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVendita,ProdottoId,TipoProdotto,PrezzoVendita,Cliente")] Vendita vendita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendita);
        }

        // GET: Vendita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendita == null)
            {
                return NotFound();
            }

            var vendita = await _context.Vendita.FindAsync(id);
            if (vendita == null)
            {
                return NotFound();
            }
            return View(vendita);
        }

        // POST: Vendita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataVendita,ProdottoId,TipoProdotto,PrezzoVendita,Cliente")] Vendita vendita)
        {
            if (id != vendita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenditaExists(vendita.Id))
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
            return View(vendita);
        }

        // GET: Vendita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendita == null)
            {
                return NotFound();
            }

            var vendita = await _context.Vendita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendita == null)
            {
                return NotFound();
            }

            return View(vendita);
        }

        // POST: Vendita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendita == null)
            {
                return Problem("Entity set 'ProgettoComplessoIDContext.Vendita'  is null.");
            }
            var vendita = await _context.Vendita.FindAsync(id);
            if (vendita != null)
            {
                _context.Vendita.Remove(vendita);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenditaExists(int id)
        {
          return (_context.Vendita?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
