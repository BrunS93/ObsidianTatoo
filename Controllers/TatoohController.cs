using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using herramientas_parcial1_brunosilva.Models;

namespace herramientas_parcial1_brunosilva.Controllers
{
    public class TatoohController : Controller
    {
        private readonly ClienteContext _context;

        public TatoohController(ClienteContext context)
        {
            _context = context;
        }

        // GET: Tatooh
        public async Task<IActionResult> Index()
        {
              return _context.Tatooh != null ? 
                          View(await _context.Tatooh.ToListAsync()) :
                          Problem("Entity set 'ClienteContext.Tatooh'  is null.");
        }

        // GET: Tatooh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tatooh == null)
            {
                return NotFound();
            }

            var tatooh = await _context.Tatooh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatooh == null)
            {
                return NotFound();
            }

            return View(tatooh);
        }

        // GET: Tatooh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tatooh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estilo,Sesiones,Precio")] Tatooh tatooh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tatooh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tatooh);
        }

        // GET: Tatooh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tatooh == null)
            {
                return NotFound();
            }

            var tatooh = await _context.Tatooh.FindAsync(id);
            if (tatooh == null)
            {
                return NotFound();
            }
            return View(tatooh);
        }

        // POST: Tatooh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estilo,Sesiones,Precio")] Tatooh tatooh)
        {
            if (id != tatooh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tatooh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TatoohExists(tatooh.Id))
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
            return View(tatooh);
        }

        // GET: Tatooh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tatooh == null)
            {
                return NotFound();
            }

            var tatooh = await _context.Tatooh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tatooh == null)
            {
                return NotFound();
            }

            return View(tatooh);
        }

        // POST: Tatooh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tatooh == null)
            {
                return Problem("Entity set 'ClienteContext.Tatooh'  is null.");
            }
            var tatooh = await _context.Tatooh.FindAsync(id);
            if (tatooh != null)
            {
                _context.Tatooh.Remove(tatooh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TatoohExists(int id)
        {
          return (_context.Tatooh?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
