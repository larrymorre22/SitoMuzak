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
    public class GadgetController : Controller
    {
        private readonly ProgettoComplessoIDContext _context;

        public GadgetController(ProgettoComplessoIDContext context)
        {
            _context = context;
        }

        // GET: Gadget
        public async Task<IActionResult> Index()
        {
              return _context.Gadget != null ? 
                          View(await _context.Gadget.ToListAsync()) :
                          Problem("Entity set 'ProgettoComplessoIDContext.Gadget'  is null.");
        }

        // GET: Gadget/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gadget == null)
            {
                return NotFound();
            }

            var gadget = await _context.Gadget
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gadget == null)
            {
                return NotFound();
            }

            return View(gadget);
        }

        // GET: Gadget/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gadget/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descrizione,Prezzo")] Gadget gadget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gadget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gadget);
        }

        // GET: Gadget/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gadget == null)
            {
                return NotFound();
            }

            var gadget = await _context.Gadget.FindAsync(id);
            if (gadget == null)
            {
                return NotFound();
            }
            return View(gadget);
        }

        // POST: Gadget/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descrizione,Prezzo")] Gadget gadget)
        {
            if (id != gadget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gadget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GadgetExists(gadget.Id))
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
            return View(gadget);
        }

        // GET: Gadget/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gadget == null)
            {
                return NotFound();
            }

            var gadget = await _context.Gadget
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gadget == null)
            {
                return NotFound();
            }

            return View(gadget);
        }

        // POST: Gadget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gadget == null)
            {
                return Problem("Entity set 'ProgettoComplessoIDContext.Gadget'  is null.");
            }
            var gadget = await _context.Gadget.FindAsync(id);
            if (gadget != null)
            {
                _context.Gadget.Remove(gadget);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GadgetExists(int id)
        {
          return (_context.Gadget?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
